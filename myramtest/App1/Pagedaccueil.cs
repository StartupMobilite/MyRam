using System.Collections.Generic; 
 using Android.App; 
 using Android.Content; 
 using Android.OS; 
 using Android.Widget; 
 using Tasky.Shared; 
 using TaskyAndroid; 
 using TaskyAndroid.ApplicationLayer; 
 using Android.Content.PM; 
 
 
 namespace TaskyAndroid.Screens
 { 
 	
 	[Activity (Label = "Tasky",   
 		Icon="@drawable/icon", 
 		MainLauncher = true, 
 		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
 		ScreenOrientation = ScreenOrientation.Portrait)] 
 	public class HomeScreen : Activity  
 	{ 
 		TodoItemListAdapter taskList; 
 		IList<TodoItem> tasks; 
 		Button addTaskButton; 
 		ListView taskListView; 
 		 
 		protected override void OnCreate(Bundle bundle)
 		{ 
 			base.OnCreate(bundle); 
 
 
 			
 			SetContentView(Resource.Layout.HomeScreen); 
 
 
 		
 			taskListView = FindViewById<ListView> (Resource.Id.TaskList); 
 			addTaskButton = FindViewById<Button> (Resource.Id.AddButton); 
 
 
 			 
 			if(addTaskButton != null) { 
 				addTaskButton.Click += (sender, e) => { 
 					StartActivity(typeof(TodoItemScreen)); 
 				}; 
 			} 
 			 
 			
 			if(taskListView != null) { 
 				taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => { 
 					var taskDetails = new Intent(this, typeof(TodoItemScreen)); 
 					taskDetails.PutExtra ("TaskID", tasks[e.Position].ID); 
 					StartActivity(taskDetails); 
 				}; 
 			} 
 		} 
 		 
 		protected override void OnResume()
 		{ 
 			base.OnResume(); 
 
 
 			tasks = TodoItemManager.GetTasks(); 
 			 
 			
 			taskList = new TodoItemListAdapter(this, tasks); 
 
 
 			
 			taskListView.Adapter = taskList; 
 		} 
 	} 
 } 
