using System.Collections.Generic; 
using Android.App;
using Android.Widget; 
using Tasky.Shared;  
 
namespace TaskyAndroid.ApplicationLayer
 { 
 	
	public class TodoItemListAdapter : BaseAdapter<TodoItem>  
 	{ 
 		Activity context = null; 
 		IList<TodoItem> tasks = new List<TodoItem>(); 
 		 
 		public TodoItemListAdapter(Activity context, IList<TodoItem> tasks) : base()
 		{ 
 			this.context = context; 
 			this.tasks = tasks; 
 		} 
 		 
 		public override TodoItem this[int position]
 		{
              get { return tasks[position]; }
          } 
	 
 		public override long GetItemId (int position) 
 		{
              return position;
          } 
	 
 		public override int Count 
 		{
              get { return tasks.Count; }
          } 
	 
 		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent) 
 		{
     			 
        var item = tasks[position];
    

		
          var view = (convertView ??
              context.LayoutInflater.Inflate(
                  Android.Resource.Layout.SimpleListItemChecked,
                  parent,
                  false)) as CheckedTextView;
              view.SetText(item.Name == "" ? "<new task>" : item.Name, TextView.BufferType.Normal);
              view.Checked = item.Done;
    



 			
          return view;
          }
 	} 
 }

