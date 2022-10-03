<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	TaskExample();	
	TaskFactoryExample();
}

static void TaskExample()	//Creating Task - Way 1
{
	Task task = new Task(Print);
	task.Start();
	task.Wait(); 
}

static void TaskFactoryExample() 	//Creating Task - Way 2
{
	//No need to write task.Start();
	Task task = Task.Factory.StartNew (() => Print);
	task.Wait();
}


static void ThreadExample()
{
	Thread thread = new Thread(Print);
	thread.Start();
	thread.Join();
}



static void Print()
{
	for (int i = 0; i < 10; i++)
	{
		$"{i} \t Thread Id:> {Thread.CurrentThread.ManagedThreadId}".Dump();
	}
}




// You can define other methods, fields, classes and namespaces here