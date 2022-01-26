using PatikaOdev3.Business.Absract;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.Model.Common;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDAL _roleDAL;

        public RoleManager(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        /// <summary>
        /// Gönderilen Rol bilgilerine göre veritabanından silme işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Delete(Role role)
        {
            try
            {

                Role roleInDb = _roleDAL.Get(x => x.Id == role.Id);

                //Role Kontrol ve Sonucuna Söre Silme İşlemleri
                if (roleInDb == null)
                {
                    return BaseControl.DeleteControl("Rol", roleInDb, 0);
                }
                else
                {
                    return BaseControl.DeleteControl("Rol", roleInDb, _roleDAL.Delete(roleInDb));
                }
            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }


        /// <summary>
        /// Gönderilen Id'ye göre veritabanından Rol silme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Delete(int id)
        {
            return this.Delete(new Role { Id = id });

        }

        public List<Role> GetUndeletedRoleList()
        {
            return _roleDAL.GetAll(x => x.IsDelete == true);
        }

        public Role GetById(int id)
        {
            return _roleDAL.GetById(id);
        }


        /// <summary>
        /// Veritabanına yeni Rol ekleme işlemleri.
        /// </summary>
        /// <param name="Role"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Insert(Role role)
        {
            try
            {
                Role roleInDb = _roleDAL.Get(x => x.Name == role.Name);

                //Role Kontrol ve Sonucuna Söre Kayıt İşlemleri
                if (roleInDb == null)
                {
                    return BaseControl.AddControl("Rol", roleInDb, _roleDAL.Insert(role));
                }
                return BaseControl.AddControl("Rol", roleInDb, 0);

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }



        }


        /// <summary>
        /// Rol güncelleme işlemleri
        /// </summary>
        /// <param name="Role"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Update(Role role)
        {

            try
            {
                Role roleInDb = _roleDAL.Get(x => x.Id == role.Id);

                //Role Kontrol ve Sonucuna Söre Güncelleme İşlemleri
                if (roleInDb == null)
                {
                    return BaseControl.UpdateControl("Rol", roleInDb, 0);
                }
                else
                {
                    return BaseControl.UpdateControl("Rol", roleInDb, _roleDAL.Update(role));
                }

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }

        public Role GetUnDeletedRole(string name)
        {
            return _roleDAL.Get(x => x.Name == name && x.IsDelete == true);
        }
    }
}
