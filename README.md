FastHttpRequest
===============

基于HTTP协议提供轻量级的请求辅助类库。

* 默认提供 GET HEAD POST PUT DELETE PATCH 方法
* 支持基于异步编程方式
* 支持基于任务编程方式

Sync Invoker
---
```csharp

//post
string url = "http://localhost:3982/home/post"; 

var result = HttpHelper.Post(url, new { name = "Johnwu", age = 30 });

var result = HttpHelper.Post(url, "name=JohnWu&age=30");

IDictionary dic = new Hashtable();
dic["name"] = "JohnWu";
dic["age"] = 123;
var result = HttpHelper.Post(url, dic);

//get
string url = "http://localhost:3982/";  
var result = HttpHelper.Get(url); 

//upload
string url = "http://localhost:3982/home/upload";
var parameters = new { name = "提交文件内容", age = 23 };
var file = AppDomain.CurrentDomain.BaseDirectory + "/hello.txt";
File.WriteAllText(file, "hello upload.");
var result = HttpHelper.Upload(url, new[] { new HttpHelper.NamedFileStream("t1", "hello2.txt",
File.OpenRead(file)) }, parameters);

```

Async Invoker
---
```csharp

//post
string url = "http://localhost:3982/home/post"; 
HttpHelper.Post(url, new { name = "Johnwu", age = 30 }, (string c) =>
{
  Console.WriteLine(c);
});

//get
string url = "http://localhost:3982/";  
HttpHelper.Get(url, (c) =>
{
  var sr = new StreamReader(c.Result);
  Console.WriteLine(sr.ReadToEnd());
});

//upload
string url = "http://localhost:3982/home/upload";
var parameters = new { name = "JohnWu", age = 23 };
var file = AppDomain.CurrentDomain.BaseDirectory + "/hello.txt";
File.WriteAllText(file, "hello upload.");
HttpHelper.Upload(url, new[] { new HttpHelper.NamedFileStream("t1", "hello.txt", File.OpenRead(file)) }, (c) =>
{
    var sr = new StreamReader(c.Result);
    Console.WriteLine(sr.ReadToEnd());
}, parameters, HttpHelper.HttpVerb.Post);

```

Task Invoker
---
```csharp

//post
HttpHelper.PostTask(url, new { name = "Johnwu", age = 30 }).ContinueWith(x =>
{
    Console.WriteLine(x.Result.ToStringResult());
});

//get
HttpHelper.GetTask(url).ContinueWith(x =>
{
    Console.WriteLine(x.Result.ToStringResult());
});

HttpHelper.GetTask(url, new { name = "Johnwu", age = 30 }).ContinueWith(x =>
{
    Console.WriteLine(x.Result.ToStringResult());
});

//upload
string url = "http://localhost:3982/home/upload";
var parameters = new { name = "JohnWu", age = 30 };
var file = AppDomain.CurrentDomain.BaseDirectory + "/hello.txt";
File.WriteAllText(file, "hello upload.");
HttpHelper.UploadTask(
url,
new[] { new HttpHelper.NamedFileStream("t1", "hello.txt", File.OpenRead(file)) },
parameters,
method: HttpHelper.HttpVerb.Post)
.ContinueWith(x =>
{
    Console.WriteLine(x.Result.ToStringResult());
});

```
