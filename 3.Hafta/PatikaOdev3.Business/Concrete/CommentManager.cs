using PatikaOdev3.Business.Absract;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.Model.Common;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDAL _commentDAL;

        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        /// <summary>
        /// Gönderilen Yorum bilgilerine göre veritabanından silme işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Delete(Comment comment)
        {
            try
            {

                Comment commentInDb = _commentDAL.Get(x => x.Id == comment.Id);

                //Comment Kontrol ve Sonucuna Söre Silme İşlemleri
                if (commentInDb == null)
                {
                    return BaseControl.DeleteControl("Comment", commentInDb, 0);
                }
                else
                {
                    return BaseControl.DeleteControl("Comment", commentInDb, _commentDAL.Delete(commentInDb));
                }
            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }


        /// <summary>
        /// Gönderilen Id'ye göre veritabanından Yorum silme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Delete(int id)
        {
            return this.Delete(new Comment { Id = id });

        }

        public List<Comment> GetUndeletedCommentList()
        {
            return _commentDAL.GetAll(x => x.IsDelete == true, "Article");
        }

        public Comment GetById(int id)
        {
            return _commentDAL.GetById(id, "Article");
        }


        /// <summary>
        /// Veritabanına yeni Yorum ekleme işlemleri.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>

        public EntityResult Insert(Comment comment)
        {
            EntityResult entityResult = new EntityResult();

            try
            {
                if (_commentDAL.Insert(comment) > 0)
                {
                    entityResult.IsSuccess = true;
                    entityResult.Message = "İşlem başarılı";                   
                }
                else
                {
                    entityResult.IsSuccess = false;
                    entityResult.Message = "İşlem başarısız!";
                    entityResult.Errors.Add("Yorum ekleme işlemi esnasında beklenmedik hata oluştu! Lütfen daha sonra yeniden deneyiniz.");
                }
                return entityResult;
            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }
        }


        /// <summary>
        /// Yorum güncelleme işlemleri
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>EntityResult tipinde sonuç değeri döner.</returns>
        public EntityResult Update(Comment comment)
        {
            try
            {
                Comment commentInDb = _commentDAL.Get(x => x.Id == comment.Id);

                //Comment Kontrol ve Sonucuna Söre Güncelleme İşlemleri
                if (commentInDb == null)
                {
                    return BaseControl.UpdateControl("Yorum", commentInDb, 0);
                }
                else
                {
                    return BaseControl.UpdateControl("Yorum", commentInDb, _commentDAL.Update(comment));
                }

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }
    }
}
