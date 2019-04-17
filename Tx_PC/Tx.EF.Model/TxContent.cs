namespace Tx.EF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TxContext : DbContext
    {
        public TxContext()
            : base("name=TxContent")
        {
        }

        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        public virtual DbSet<EnterprisePrice> EnterprisePrice { get; set; }
        public virtual DbSet<NewsAdvertisement> NewsAdvertisement { get; set; }
        public virtual DbSet<NewsArticles> NewsArticles { get; set; }
        public virtual DbSet<NewsArticles_old1> NewsArticles_old1 { get; set; }
        public virtual DbSet<NewsArticleText> NewsArticleText { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }
        public virtual DbSet<NewsFavorite> NewsFavorite { get; set; }
        public virtual DbSet<NewsLink> NewsLink { get; set; }
        public virtual DbSet<NewsLog> NewsLog { get; set; }
        public virtual DbSet<NewsResources> NewsResources { get; set; }
        public virtual DbSet<NewsSort> NewsSort { get; set; }
        public virtual DbSet<NewsSortStyles> NewsSortStyles { get; set; }
        public virtual DbSet<NewsSortType> NewsSortType { get; set; }
        public virtual DbSet<NewsViewSort> NewsViewSort { get; set; }
        public virtual DbSet<NewsVisitHistory> NewsVisitHistory { get; set; }
        public virtual DbSet<OnlineAnswer> OnlineAnswer { get; set; }
        public virtual DbSet<OnlineQuestions> OnlineQuestions { get; set; }
        public virtual DbSet<PredictionMarket> PredictionMarket { get; set; }
        public virtual DbSet<PredictionPrice> PredictionPrice { get; set; }
        public virtual DbSet<PredictionProduct> PredictionProduct { get; set; }
        public virtual DbSet<Price_Code> Price_Code { get; set; }
        public virtual DbSet<SmsMarket2> SmsMarket2 { get; set; }
        public virtual DbSet<SmsPrice2> SmsPrice2 { get; set; }
        public virtual DbSet<SmsProduct3> SmsProduct3 { get; set; }
        public virtual DbSet<VoteDetails> VoteDetails { get; set; }
        public virtual DbSet<VoteIPList> VoteIPList { get; set; }
        public virtual DbSet<VoteMaster> VoteMaster { get; set; }
        public virtual DbSet<XHMarketGroup> XHMarketGroup { get; set; }
        public virtual DbSet<AjaxPrice> AjaxPrice { get; set; }
        public virtual DbSet<NewsArticle20170821> NewsArticle20170821 { get; set; }
        public virtual DbSet<NewsSort_Bak> NewsSort_Bak { get; set; }
        public virtual DbSet<NewsSort_Bak1> NewsSort_Bak1 { get; set; }
        public virtual DbSet<SmsMarket> SmsMarket { get; set; }
        public virtual DbSet<SmsPrice> SmsPrice { get; set; }
        public virtual DbSet<SmsProduct> SmsProduct { get; set; }
        public virtual DbSet<EnterprisePriceView> EnterprisePriceView { get; set; }
        public virtual DbSet<GetMarketNamePriceTimeFromGroupID> GetMarketNamePriceTimeFromGroupID { get; set; }
        public virtual DbSet<PredictionMarketPrice> PredictionMarketPrice { get; set; }
        public virtual DbSet<View_APriceMarPro> View_APriceMarPro { get; set; }
        public virtual DbSet<View_GetProductPriceFromMarketID> View_GetProductPriceFromMarketID { get; set; }
        public virtual DbSet<View_Prediction> View_Prediction { get; set; }
        public virtual DbSet<View_PriceMarPro> View_PriceMarPro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerInfo>()
                .Property(e => e.TempBak1)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInfo>()
                .Property(e => e.TempBak8)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CustomerInfo>()
                .Property(e => e.TempBak9)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Enterprise>()
                .Property(e => e.TempBak1)
                .IsUnicode(false);

            modelBuilder.Entity<Enterprise>()
                .Property(e => e.TempBak8)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Enterprise>()
                .Property(e => e.TempBak9)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EnterprisePrice>()
                .Property(e => e.TempBak1)
                .IsUnicode(false);

            modelBuilder.Entity<EnterprisePrice>()
                .Property(e => e.TempBak8)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EnterprisePrice>()
                .Property(e => e.TempBak9)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NewsArticleText>()
                .Property(e => e.ArticleText)
                .IsUnicode(false);

            modelBuilder.Entity<NewsComment>()
                .Property(e => e.CommentContent)
                .IsUnicode(false);

            modelBuilder.Entity<NewsLink>()
                .Property(e => e.LinkName)
                .IsUnicode(false);

            modelBuilder.Entity<NewsLink>()
                .Property(e => e.LinkAddress)
                .IsUnicode(false);

            modelBuilder.Entity<NewsLink>()
                .Property(e => e.LinkIcon)
                .IsUnicode(false);

            modelBuilder.Entity<NewsLog>()
                .Property(e => e.NewsTitle)
                .IsUnicode(false);

            modelBuilder.Entity<NewsLog>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<NewsLog>()
                .Property(e => e.CreateMid)
                .IsUnicode(false);

            modelBuilder.Entity<NewsLog>()
                .Property(e => e.DeleteMid)
                .IsUnicode(false);

            modelBuilder.Entity<NewsSortStyles>()
                .Property(e => e.StyleName)
                .IsUnicode(false);

            modelBuilder.Entity<NewsSortStyles>()
                .Property(e => e.StyleSkin)
                .IsUnicode(false);

            modelBuilder.Entity<NewsVisitHistory>()
                .Property(e => e.VisitIP)
                .IsUnicode(false);

            modelBuilder.Entity<NewsVisitHistory>()
                .Property(e => e.VisitPage)
                .IsUnicode(false);

            modelBuilder.Entity<OnlineAnswer>()
                .Property(e => e.MessageText)
                .IsUnicode(false);

            modelBuilder.Entity<OnlineAnswer>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<OnlineQuestions>()
                .Property(e => e.QuestionsTitle)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionMarket>()
                .Property(e => e.MarketName)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionPrice>()
                .Property(e => e.LPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PredictionPrice>()
                .Property(e => e.HPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PredictionPrice>()
                .Property(e => e.APrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PredictionPrice>()
                .Property(e => e.MID)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionPrice>()
                .Property(e => e.Change)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionProduct>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.LPrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.HPrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.APrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.Water)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.NewPrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.Storehouse)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.StrikeBargain)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.Stock)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.SpecialL)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice2>()
                .Property(e => e.SpecialH)
                .IsUnicode(false);

            modelBuilder.Entity<SmsProduct3>()
                .Property(e => e.ProductSum)
                .HasPrecision(29, 0);

            modelBuilder.Entity<SmsProduct3>()
                .Property(e => e.Format)
                .IsUnicode(false);

            modelBuilder.Entity<VoteDetails>()
                .Property(e => e.voteItem)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VoteIPList>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<VoteMaster>()
                .Property(e => e.voteTitle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<XHMarketGroup>()
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.LPrice)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.HPrice)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.APrice)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.Water)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.NewPrice)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.Storehouse)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.StrikeBargain)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.Stock)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.SpecialL)
                .IsUnicode(false);

            modelBuilder.Entity<AjaxPrice>()
                .Property(e => e.SpecialH)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.LPrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.HPrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.APrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.Water)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.NewPrice)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.Storehouse)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.StrikeBargain)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.Stock)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.SpecialL)
                .IsUnicode(false);

            modelBuilder.Entity<SmsPrice>()
                .Property(e => e.SpecialH)
                .IsUnicode(false);

            modelBuilder.Entity<SmsProduct>()
                .Property(e => e.ProductSum)
                .HasPrecision(29, 0);

            modelBuilder.Entity<SmsProduct>()
                .Property(e => e.Format)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionMarketPrice>()
                .Property(e => e.MarketName)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionMarketPrice>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionMarketPrice>()
                .Property(e => e.HPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PredictionMarketPrice>()
                .Property(e => e.LPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PredictionMarketPrice>()
                .Property(e => e.Change)
                .IsUnicode(false);

            modelBuilder.Entity<PredictionMarketPrice>()
                .Property(e => e.MID)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.LPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.HPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.APrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.Water)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.NewPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.Storehouse)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.StrikeBargain)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.Stock)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.SpecialL)
                .IsUnicode(false);

            modelBuilder.Entity<View_APriceMarPro>()
                .Property(e => e.SpecialH)
                .IsUnicode(false);

            modelBuilder.Entity<View_GetProductPriceFromMarketID>()
                .Property(e => e.HPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_GetProductPriceFromMarketID>()
                .Property(e => e.LPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_GetProductPriceFromMarketID>()
                .Property(e => e.APrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_Prediction>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<View_Prediction>()
                .Property(e => e.LPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<View_Prediction>()
                .Property(e => e.HPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<View_Prediction>()
                .Property(e => e.APrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<View_Prediction>()
                .Property(e => e.Change)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.LPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.HPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.APrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.Water)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.NewPrice)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.Storehouse)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.StrikeBargain)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.Stock)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.SpecialL)
                .IsUnicode(false);

            modelBuilder.Entity<View_PriceMarPro>()
                .Property(e => e.SpecialH)
                .IsUnicode(false);
        }
    }
}
