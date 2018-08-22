using System;
using System.Threading;

namespace Notes.Model
{
    public class NotesWithUser : Note
    {
	    public NotesWithUser(Note note)
	    {
		    if (note == null)
			    throw new ArgumentException("Parameter notes must not be null");

		    Text = note.Text;
		    Id = note.Id;
		    OwnerId = note.OwnerId;
	    }

	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	}
}
