using PatikaOdev3.Business.Absract;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.Model.Common;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDAL _articleDAL;

        public ArticleManager(IArticleDAL articleDAL)
        {
            _articleDAL = articleDAL;
        }


        public EntityResult Delete(Article article)
        {
            try
            {
                Article articleInDb = _articleDAL.Get(x => x.Id == article.Id);

                //Makale Kontrol ve Sonucuna Söre Silme İşlemleri
                if (articleInDb == null)
                {
                    return BaseControl.DeleteControl("Makale", articleInDb, 0);
                }
                else
                {
                    return BaseControl.DeleteControl("Makale", articleInDb, _articleDAL.Delete(articleInDb));
                }

            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }

        }

        public EntityResult Delete(int id)
        {
            return this.Delete(new Article { Id = id });
        }

        //Id'ye göre makale getirir.
        public Article GetById(int id)
        {
            return _articleDAL.GetById(id, "Category");
        }

        //Silinmemiş makaleleri başlığına göre getirir.
        public List<Article> GetUndeletedArticleWithTitle(string title)
        {
            return _articleDAL.GetAll(x => x.IsDelete == true && x.Title.Contains(title), "Category");
        }

        //Silinmemiş tüm makalelerin listesini getirir.
        public List<Article> GetUndeletedArticleList()
        {
            return _articleDAL.GetAll(x => x.IsDelete, "Category");
        }

        public EntityResult Insert(Article article)
        {
            try
            {

                Article articleInDb = _articleDAL.Get(x => x.Title == article.Title);

                //Article Kontrol ve Sonucuna Söre Kayıt İşlemleri
                if (articleInDb == null)
                {
                    return BaseControl.AddControl("Makale", articleInDb, _articleDAL.Insert(article));
                }
                else
                {
                    return BaseControl.AddControl("Makale", articleInDb, 0);
                }


            }
            catch (Exception ex)
            {
                //Hata loglama işlemleri burada yapılacak.
                throw new Exception("Beklenmedik bir hata oluştu! Lütfen daha sonra tekrar deneyiniz.");
            }
        }

        public EntityResult Update(Article article)
        {
            try
            {

                Article articleInDb = _articleDAL.Get(x => x.Id == article.Id);

                //Article Kontrol ve Sonucuna Söre Günceleme İşlemleri
                if (articleInDb == null)
                {
                    return BaseControl.UpdateControl("Makale", articleInDb, 0);
                }
                else
                {
                    return BaseControl.UpdateControl("Makale", articleInDb, _articleDAL.Update(article));
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
