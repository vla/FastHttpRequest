properties {
  $tfver = "v4.0";
  $config = "Release"
  $base_version = "1.0.3" 
  $base_dir = Split-Path $psake.build_script_file 

  $src_dir = "$base_dir"
  $tools_dir = "$base_dir\tools"
  $artifacts_dir = "$base_dir\artifacts"
  $bin_dir = "$artifacts_dir\bin\"
  $lib_file = "$base_dir\Src\HttpRequest\HttpRequest.csproj"
  $nuspec_file = "$base_dir\fasthttprequest.nuspec"

  $nuget_tool = "$tools_dir\nuget\nuget.exe"
  $zip_tool = "$tools_dir\7Zip\7za.exe"
}

function RemoveDirectory($path) {
  if(Test-Path $path) {
    rd -rec -force $path | out-null
  }
}

Framework('4.0')

function BuildHasBeenRun {
    $build_exists = (Test-Path $bin_dir)
    Assert $build_exists "Build task has not been run."
    $true
}

Task default -depends Compile

Task Compile -depends Clean { 
  mkdir -path $bin_dir | out-null
  Write-Host "Building $lib_file for .NET $tfver" -ForegroundColor Green
  Exec { msbuild "$lib_file" /t:Rebuild /p:Configuration=$config /p:TargetFrameworkVersion=$tfver /v:quiet /p:OutDir=$bin_dir /p:Platform=AnyCPU } 

  $zip_dir = "$artifacts_dir\ziptemp"
    
  RemoveDirectory $zip_dir

  mkdir -path $zip_dir | out-null
    
  $items = @("$bin_dir\HttpRequest.dll", `
        "$bin_dir\HttpRequest.XML")
  cp $items "$zip_dir"
  $short_version = $base_version
  if($base_version.EndsWith(".0")) {
    $short_version = $base_version.SubString(0, $base_version.Length - 2)
  }

  Exec { &$zip_tool a "$artifacts_dir\FastHttpRequest-$short_version.zip" "$zip_dir\*" }

  rd $zip_dir -rec -force | out-null
}

Task Clean { 
    RemoveDirectory $artifacts_dir
    Write-Host "Cleaning $lib_file" -ForegroundColor Green
    Exec { msbuild "$lib_file" /t:Clean /p:Configuration=$config /v:quiet } 
}

