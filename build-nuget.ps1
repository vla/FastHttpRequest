properties {

  $base_version = "1.0.4" 
  $base_dir = Split-Path $psake.build_script_file 

  $tools_dir = "$base_dir\tools"
  $artifacts_dir = "$base_dir\artifacts"
  $bin_dir = "$artifacts_dir\bin\"
  $nuspec_file = "$base_dir\fasthttprequest.nuspec"
  $nuget_tool = "$tools_dir\nuget\nuget.exe"

}

Framework('4.0')

function BuildHasBeenRun {
    $build_exists = (Test-Path $bin_dir)
    Assert $build_exists "Build task has not been run."
    $true
}

Task default -depends NugetPack

task NugetPack -precondition { (BuildHasBeenRun) } {

    $nf = $nuspec_file

    Exec { &$nuget_tool pack $nf -o $artifacts_dir -Version $base_version -Symbols -BasePath $base_dir }
}