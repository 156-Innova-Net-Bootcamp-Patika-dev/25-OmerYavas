using PatikaOdev3.Business.Absract;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.Model.Common;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        /// <summary>
        /// Gönderilen Kullanıcı bilgilerine göre veritabanından silme işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Delete(User user)
        {
            try
            {

                User userInDb = _userDAL.Get(x => x.Id == user.Id);

                //User Kontrol ve Sonucuna Söre Silme İşlemleri
                if (userInDb == null)
                {
                    return BaseControl.DeleteControl("Kullanıcı", userInDb, 0);
                }
                else
                {
                    return BaseControl.DeleteControl("Kullanıcı", userInDb, _userDAL.Delete(userInDb));
                }
            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }


        /// <summary>
        /// Gönderilen Id'ye göre veritabanından Kullanıcı silme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Delete(int id)
        {
            return this.Delete(new User { Id = id });

        }

        public List<User> GetUndeletedUserList()
        {
            return _userDAL.GetAll(x => x.IsDelete == true, "Role", "Gender");
        }

        public User GetById(int id)
        {
            return _userDAL.GetById(id, "Role", "Gender");
        }


        /// <summary>
        /// Veritabanına yeni Kullanıcı ekleme işlemleri.
        /// </summary>
        /// <param name="User"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Insert(User user)
        {
            try
            {
                User userInDb = _userDAL.Get(x => x.UserName == user.UserName);

                //User Kontrol ve Sonucuna Söre Kayıt İşlemleri
                if (userInDb == null)
                {
                    return BaseControl.AddControl("Kullanıcı", userInDb, _userDAL.Insert(user));
                }
                return BaseControl.AddControl("Kullanıcı", userInDb, 0);

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }



        }


        /// <summary>
        /// Kullanıcı güncelleme işlemleri
        /// </summary>
        /// <param name="user"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Update(User user)
        {

            try
            {
                User userInDb = _userDAL.Get(x => x.Id == user.Id);

                //User Kontrol ve Sonucuna Söre Güncelleme İşlemleri
                if (userInDb == null)
                {
                    return BaseControl.UpdateControl("Kullanıcı", userInDb, 0);
                }
                else
                {
                    return BaseControl.UpdateControl("Kullanıcı", userInDb, _userDAL.Update(user));
                }

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }

        public User GetUnDeletedUserWithUserName(string userName)
        {
            return _userDAL.Get(x => x.FirstName == userName && x.IsDelete == true, "Role", "Gender");
        }
    }
}
