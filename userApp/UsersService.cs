using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using userApp.Models;

namespace userApp
{
    public class UsersService
    {
        UsersDBEntities usersDBEntities = new UsersDBEntities();
        public IList<User> GetUsersList()
        {
            return usersDBEntities.Users.ToList();
        }

        public UserEditorModel PrepareUserEditorModel(int? userId)
        {
            UserEditorModel model = new UserEditorModel();


            if(userId.GetValueOrDefault() > 0)
            {
              User savedUser =  usersDBEntities.Users.FirstOrDefault(x => x.UserID == userId);

                if(savedUser != null)
                {
                    model.UserID = savedUser.UserID;
                    model.UserName = savedUser.UserName;
                    model.Password = savedUser.Password;
                    model.Age = savedUser.Age;
                    model.MobileNo = savedUser.MobileNo;
                    model.NationalityID = savedUser.NationalityID;
                    model.CompanyID = savedUser.CompanyID;
                    model.Address = savedUser.Address;
                }
            }


            // Nationalities
            model.NationalitiesList = new List<SelectListItem>();

            IList<Nationality> nationalitiesList = usersDBEntities.Nationalities.ToList();

            model.NationalitiesList.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "--select--",
                Value = ""
            });

            if (nationalitiesList.Count > 0)
            {
                foreach(Nationality nationality in nationalitiesList)
                {
                  SelectListItem listItem = new SelectListItem
                  {
                      Text = nationality.NationalityName,
                      Value = nationality.NationalityID.ToString()
                  };

                    model.NationalitiesList.Add(listItem);
                }
            }


            // Companies
            model.CompaniesList = new List<SelectListItem>();

            IList<Company> companiesList = usersDBEntities.Companies.ToList();

            model.CompaniesList.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "--select--",
                Value = ""
            });

            if (companiesList.Count > 0)
            {
                foreach (Company company in companiesList)
                {
                    SelectListItem listItem = new SelectListItem
                    {
                        Text = company.CompanyName,
                        Value = company.CompanyID.ToString()
                    };

                    model.CompaniesList.Add(listItem);
                }
            }

            return model;
        }

        public void SaveUser(UserEditorModel model)
        {

            User newUser = new User();

            if (model.UserID > 0)
            {
                User savedUser = usersDBEntities.Users.FirstOrDefault(x => x.UserID == model.UserID);

                newUser = savedUser;
            }

            newUser.UserName = model.UserName;
            newUser.Password = model.Password;
            newUser.Age = model.Age;
            newUser.Address = model.Address;
            newUser.NationalityID = model.NationalityID;
            newUser.CompanyID = model.CompanyID;
            newUser.MobileNo = model.MobileNo;


            if(model.UserID == 0)
            {
                usersDBEntities.Users.Add(newUser);
            }

            usersDBEntities.SaveChanges();
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                User savedUser = usersDBEntities.Users.FirstOrDefault(x => x.UserID == userId);

                usersDBEntities.Users.Remove(savedUser);

                usersDBEntities.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}