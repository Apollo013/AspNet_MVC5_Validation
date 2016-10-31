using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AspNet_MVC5_Validation.Models
{
    public class RegisteredUsers : IEnumerable
    {
        private Dictionary<string, RegisterVM> users = new Dictionary<string, RegisterVM>();

        public int Count { get { return users.Count; } }
        public RegisterVM this[string email]
        {
            get { return TryGet(email); }
            set { users[email] = value; }
        }

        public void Add(RegisterVM user)
        {
            RegisterVM curuser = null;
            if (users.TryGetValue(user.Email, out curuser))
            {
                Update(user);
            }
            else
            {
                users.Add(user.Email, user);
            }
        }

        public RegisterVM TryGet(string email)
        {
            RegisterVM ru = null;
            users.TryGetValue(email, out ru);
            return ru;
        }

        public void Update(RegisterVM user)
        {
            users[user.Email] = user;
        }

        public void Delete(string email)
        {
            users.Remove(email);
        }

        public IEnumerable<RegisterVM> ToList()
        {
            return users.Values.ToList();
        }

        public IEnumerator GetEnumerator()
        {
            return users.GetEnumerator();
        }
    }
}