using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Shared;
using TaskyAndroid;


namespace TaskyAndroid.Screens
{
  
    [Activity(Label = "Tasky")]
    public class TodoItemScreen : Activity
    {
        TodoItem task = new TodoItem();
        Button cancelDeleteButton;
        EditText notesTextEdit;
        EditText nameTextEdit;
        Button saveButton;
        CheckBox doneCheckbox;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            int taskID = Intent.GetIntExtra("TaskID", 0);
            if (taskID > 0)
            {
                task = TodoItemManager.GetTask(taskID);
            }

            
            SetContentView(Resource.Layout.TaskDetails);
            nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
            notesTextEdit = FindViewById<EditText>(Resource.Id.NotesText);
            saveButton = FindViewById<Button>(Resource.Id.SaveButton);

            
            doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
            doneCheckbox.Checked = task.Done;

            cancelDeleteButton = FindViewById<Button>(Resource.Id.CancelDeleteButton);

      
            cancelDeleteButton.Text = (task.ID == 0 ? "Cancel" : "Delete");

            nameTextEdit.Text = task.Name;
            notesTextEdit.Text = task.Notes;

            
            cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
            saveButton.Click += (sender, e) => { Save(); };
        }

        void Save()
        {
            task.Name = nameTextEdit.Text;
            task.Notes = notesTextEdit.Text;
             
            task.Done = doneCheckbox.Checked;

            TodoItemManager.SaveTask(task);
            Finish();
        }

        void CancelDelete()
        {
            if (task.ID != 0)
            {
                TodoItemManager.DeleteTask(task.ID);
            }
            Finish();
        }
    }
}




public Class1()
	{
	}
}
