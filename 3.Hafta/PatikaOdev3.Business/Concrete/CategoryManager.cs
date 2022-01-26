using PatikaOdev3.Business.Absract;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.Model.Common;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        /// <summary>
        /// Gönderilen kategori bilgilerine göre veritabanından silme işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Delete(Category category)
        {
            try
            {

                Category categoryInDb = _categoryDAL.Get(x => x.Id == category.Id);

                //Category Kontrol ve Sonucuna Söre Silme İşlemleri
                if (categoryInDb == null)
                {
                    return BaseControl.DeleteControl("Kategori", categoryInDb, 0);
                }
                else
                {
                    return BaseControl.DeleteControl("Kategori", categoryInDb, _categoryDAL.Delete(categoryInDb));
                }
            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }


        /// <summary>
        /// Gönderilen Id'ye göre veritabanından Kategori silme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Delete(int id)
        {
            return this.Delete(new Category { Id = id });

        }

        public List<Category> GetUndeletedCategoryList()
        {
            return _categoryDAL.GetAll(x => x.IsDelete == true);
        }

        public Category GetById(int id)
        {
            return _categoryDAL.GetById(id);
        }


        /// <summary>
        /// Veritabanına yeni Kategori ekleme işlemleri.
        /// </summary>
        /// <param name="category"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Insert(Category category)
        {


            try
            {
                Category categoryInDb = _categoryDAL.Get(x => x.Name == category.Name);

                //Category Kontrol ve Sonucuna Söre Kayıt İşlemleri
                if (categoryInDb == null)
                {
                    return BaseControl.AddControl("Kategori", categoryInDb, _categoryDAL.Insert(category));
                }
                return BaseControl.AddControl("Kategori", categoryInDb, 0);

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }



        }


        /// <summary>
        /// Kategori güncelleme işlemleri
        /// </summary>
        /// <param name="category"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Update(Category category)
        {

            try
            {
                Category categoryInDb = _categoryDAL.Get(x => x.Id == category.Id);

                //Category Kontrol ve Sonucuna Söre Güncelleme İşlemleri
                if (categoryInDb == null)
                {
                    return BaseControl.UpdateControl("Kategori", categoryInDb, 0);
                }
                else
                {
                    return BaseControl.UpdateControl("Kategori", categoryInDb, _categoryDAL.Update(category));
                }

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }

        public Category GetUnDeletedCategory(string name)
        {
            return _categoryDAL.Get(x => x.Name == name && x.IsDelete == true);
        }
    }
}
