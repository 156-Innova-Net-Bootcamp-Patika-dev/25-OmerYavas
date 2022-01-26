using PatikaOdev3.Model.Common;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Concrete
{
    internal static class BaseControl
    {
        public static EntityResult AddControl<TEntity>(string entityName, TEntity entity, int count = 0)
            where TEntity : class
        {
            EntityResult entityResult = new EntityResult();
           
            try
            {                

                if (entity == null)
                {
                    if (count > 0)
                    {
                        entityResult.IsSuccess = true;
                        entityResult.Message = $"İşlem başarıyla gerçekleşti";

                    }
                    else
                    {
                        entityResult.IsSuccess = false;
                        entityResult.Message = $" gerçekleşti! Kaydetme işlemi esnasında hata oluştu!";

                        entityResult.Errors = new List<string>();
                        entityResult.Errors.Add("Beklenmedik bir hata oluştu! Lütfen yeniden deneyiniz.");
                    }
                }
                else
                {
                    entityResult.IsSuccess = false;
                    entityResult.Message = $"Kaydetme işlemi esnasında hata oluştu!";

                    entityResult.Errors = new List<string>();
                    entityResult.Errors.Add($"Kaydetmek istediğiniz {entityName} zaten veritabanında mevcut!");
                }

                return entityResult;

            }
            catch (Exception)
            {
                //Hata loglaması burada yapılacak
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen yeniden deneyiniz.");
            }

        }


        public static EntityResult UpdateControl<TEntity>(string entityName, TEntity entity, int count)
               where TEntity : class
        {

            EntityResult entityResult = new EntityResult();

            if (entity == null)
            {
                entityResult.IsSuccess = false;
                entityResult.Message = $"Günceleme işlemi başarısız!";

                entityResult.Errors = new List<string>();
                entityResult.Errors.Add($"Güncellenmek istenen {entityName} bulunamadı.");
            }
            else
            {
                if (count > 0)
                {
                    entityResult.IsSuccess = true;
                    entityResult.Message = $"Güncelleme işlemi başarıyla gerçekleşti.";
                }
                else
                {
                    entityResult.IsSuccess = false;
                    entityResult.Message = $"Güncelleme işlemi başarısız!";

                    entityResult.Errors = new List<string>();
                    entityResult.Errors.Add("Beklenmedik bir hata oluştu! Lütfen yeniden deneyiniz.");
                }


            }

            return entityResult;
        }


        public static EntityResult DeleteControl<TEntity>(string entityName, TEntity entity, int count)
           where TEntity : class
        {

            EntityResult entityResult = new EntityResult();

            if (entity == null)
            {
                entityResult.IsSuccess = false;
                entityResult.Message = $"Silme işlemi esnasında hata oluştu!";

                entityResult.Errors = new List<string>();
                entityResult.Errors.Add($"Silinmek istenen {entityName} bulunamadı.");
            }
            else
            {
                if (count > 0)
                {
                    entityResult.IsSuccess = true;
                    entityResult.Message = $"Başarıyla silindi.";
                }
                else
                {
                    entityResult.IsSuccess = false;
                    entityResult.Message = $"Silme işlemi esnasında hata oluştu!";

                    entityResult.Errors = new List<string>();
                    entityResult.Errors.Add("Beklenmedik bir hata oluştu! Lütfen yeniden deneyiniz.");
                }


            }

            return entityResult;
        }
    }
}

