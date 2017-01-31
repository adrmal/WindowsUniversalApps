using ProjectApp.model;
using System;
using System.Collections.Generic;

namespace ProjectApp.rest
{
    class RestAPIConverter
    {
        public static Note convertToNote(Contact contact)
        {
            int noteId = contact.Id;
            string noteDateString = contact.EmailAddress;
            string noteTitle = contact.Name.Split(new string[] { "\\\\\\\\\\" }, StringSplitOptions.None)[0];
            string noteDescription = contact.Name.Split(new string[] { "\\\\\\\\\\" }, StringSplitOptions.None)[1];
            int[] noteDate = new int[5];
            for(int i=0; i<5; i++)
            {
                noteDate[i] = int.Parse(noteDateString.Split('.')[i]);
            }

            Note note = new Note(noteId, noteTitle, noteDescription, new DateTime(noteDate[0], noteDate[1], noteDate[2], noteDate[3], noteDate[4], 0));
            return note;
        }

        public static List<Note> convertToNotesList(List<Contact> contacts)
        {
            List<Note> notes = new List<Note>();
            foreach(Contact contact in contacts) {
                Note note = convertToNote(contact);
                notes.Add(note);
            }
            return notes;
        }

        public static Contact convertFromNote(Note note)
        {
            Contact contact = new Contact();
            contact.Id = note.Id;
            contact.EmailAddress = note.Date.Year + "." + note.Date.Month + "." + note.Date.Day + "." + note.Date.Hour + "." + note.Date.Minute;
            contact.Name = note.Title + "\\\\\\\\\\" + note.Description;
            return contact;
        }

        public static List<Contact> convertFromNotesList(List<Note> notes)
        {
            List<Contact> contacts = new List<Contact>();
            foreach(Note note in notes)
            {
                Contact contact = convertFromNote(note);
                contacts.Add(contact);
            }
            return contacts;
        }
    }
}
