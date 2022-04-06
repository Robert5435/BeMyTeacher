using BeMyTeacher.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeMyTeacher.Core
{
    public class UserServices : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void EditUser(int id, string phoneNumber, string path)
        {
            var currentUser = GetById(id);
            currentUser.PhoneNumber = phoneNumber;
            currentUser.PhotoPath = path;
            _context.SaveChanges();

        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void RateUser(int id, int ratingGiven)
        {
            var userToBeRated = GetById(id);
            int userRating = userToBeRated.RatingUser;
            int counter = userToBeRated.RatingCounter;
            userToBeRated.RatingCounter = (counter + 1);
            if(userToBeRated.RatingCounter < 2)
            {
                userToBeRated.RatingUser = ratingGiven;
                _context.SaveChanges();
            }
            else { 
                userToBeRated.RatingUser = (userRating + ratingGiven) / 2;
                _context.SaveChanges();
            }
        }
    }
}
