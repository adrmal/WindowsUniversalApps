using ProjectApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectApp.rest
{
    class RestAPIConverter
    {
        public static Note convertToNote(Contact contact)
        {
            return null;
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
            return null;
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
