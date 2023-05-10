using Proiect_1_Sfranciog.Areas.Identity.Data;
using Proiect_1_Sfranciog.Models;

namespace Proiect_1_Sfranciog.Data
{
    public interface IDAL
    {
        public List<Event> GetEvents();
        public List<Event> GetMyEvents(string userId);
        public Event GetEvent(int id);
        public void CreateEvent(IFormCollection form);
        public void UpdateEvent(IFormCollection form);
        public void DeleteEvent(int id);
        public List<Location> GetLocations();
        public Location GetLocation(int id);
        public void CreateLocation(Location location);
    }
    public class DAL : IDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }
        public List<Event> GetMyEvents(string userId)
        {
            return db.Events.Where(x => x.User.Id == userId).ToList();
        }
        public Event GetEvent(int id)
        {
            return db.Events.FirstOrDefault(x => x.Id == id);
        }
        public void CreateEvent(IFormCollection form)
        {
            var locname = form["Location"].ToString();
            var newEvent = new Event(form, db.Locations.FirstOrDefault(x => x.Name == locname));
            db.Events.Add(newEvent);
            db.SaveChanges();
        }
        public void UpdateEvent(IFormCollection form)
        {
            var eventid = int.Parse(form["Event.Id"]);
            var locname = form["Location"].ToString();
            var myEvent = db.Events.FirstOrDefault(x => x.Id == eventid);
            var location = db.Locations.FirstOrDefault(x => x.Name == locname);
            myEvent.UpdateEvent(form, location);
            db.Entry<Event>(myEvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteEvent(int id)
        {
            var myEvent = db.Events.Find(id);
            db.Events.Remove(myEvent);
            db.SaveChanges();
        }
        public List<Location> GetLocations()
        {
            return db.Locations.ToList();
        }
        public Location GetLocation(int id)
        {
            return db.Locations.Find(id);
        }
        public void CreateLocation(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }
    }
}
