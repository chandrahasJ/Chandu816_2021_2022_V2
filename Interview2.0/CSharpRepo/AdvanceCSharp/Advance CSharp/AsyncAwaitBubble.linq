<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var watch = Stopwatch.StartNew();
	await StartProcessParallelAsync();
	watch.Stop();
	$"Total Time execution {watch.ElapsedMilliseconds} ms".Dump();
}
//Improved version by using downloading it Parallel
public async Task StartProcessParallelAsync()
{
	List<Task<WbSiteDataModel>> tasks = new List<Task<WbSiteDataModel>>();
	foreach (var urlstring in GetAllWebSiteName())
	{		
		// this is will give us the performance boost
		// since we are performing the download simultaneously
		// and then waiting for all the task to complete by using
		// Task.WhenAll
		tasks.Add(Task.Run (() => downloadWebSites(urlstring)));
	}	
	// When All will wait for all task to complete
	var results = await Task.WhenAll(tasks);	
	foreach (var taskResult in results)
	{
		ReportData(taskResult);
	}
}
//Assume this method is inside some libary 
//which doesn't have the support for async 
//await & also you don't have the source code
public WbSiteDataModel downloadWebSites(string url){
	var client = new WebClient();
	WbSiteDataModel output = new WbSiteDataModel();
	output.WebSiteUrl = url;
	output.Result = client.DownloadString(url);
	return output;	
}
public void ReportData(WbSiteDataModel dataModel)
{
	$"{dataModel.WebSiteUrl}".Dump();
}

//One Way - Only async & await
public async Task StartProcessAsync()
{
	foreach (var urlstring in GetAllWebSiteName())
	{
		//Here by using Task.Run(() => {})
		//we created a async await bubble for the 
		//method
		var result = await Task.Run(() =>
					   downloadWebSites(urlstring));
		ReportData(result);
	}
}


public List<string> GetAllWebSiteName(){
	return new List<string>(){
		"https://www.google.com/",
		"https://www.youtube.com/",
		"https://github.com",
		"https://www.facebook.com/",
		"https://www.linkedin.com/feed/",
		"https://kite.zerodha.com/dashboard",
	};
}

public class WbSiteDataModel{
	public string WebSiteUrl { get; set; }
	public string Result { get; set; }
}

// You can define other methods, fields, classes and namespaces here