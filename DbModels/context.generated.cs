﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591

using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : db
	/// Data Source    : 42.194.131.197
	/// Server Version : 8.0.28
	/// </summary>
	public partial class DbDB : LinqToDB.Data.DataConnection
	{
		public ITable<AccountArea>      AccountAreas      { get { return this.GetTable<AccountArea>(); } }
		public ITable<AiVocabulary>     AiVocabularies    { get { return this.GetTable<AiVocabulary>(); } }
		public ITable<ARTICLE>          Articles          { get { return this.GetTable<ARTICLE>(); } }
		public ITable<ArticleCategory>  ArticleCategories { get { return this.GetTable<ArticleCategory>(); } }
		public ITable<ChatRecord>       ChatRecords       { get { return this.GetTable<ChatRecord>(); } }
		public ITable<ClientVersion>    ClientVersions    { get { return this.GetTable<ClientVersion>(); } }
		public ITable<CloudStorage>     CloudStorages     { get { return this.GetTable<CloudStorage>(); } }
		public ITable<EMOJI>            Emojis            { get { return this.GetTable<EMOJI>(); } }
		public ITable<FoodImage>        FoodImages        { get { return this.GetTable<FoodImage>(); } }
		public ITable<GROUP>            GROUPS            { get { return this.GetTable<GROUP>(); } }
		public ITable<ILike>            ILikes            { get { return this.GetTable<ILike>(); } }
		public ITable<IMAGE>            Images            { get { return this.GetTable<IMAGE>(); } }
		public ITable<LYRIC>            LYRICS            { get { return this.GetTable<LYRIC>(); } }
		public ITable<MUSIC>            MUSICS            { get { return this.GetTable<MUSIC>(); } }
		public ITable<MusicInfo>        MusicInfo         { get { return this.GetTable<MusicInfo>(); } }
		public ITable<NetdiskFileInfo>  NetdiskFileInfo   { get { return this.GetTable<NetdiskFileInfo>(); } }
		public ITable<NewestChatRecord> NewestChatRecords { get { return this.GetTable<NewestChatRecord>(); } }
		public ITable<PlayCount>        PlayCounts        { get { return this.GetTable<PlayCount>(); } }
		public ITable<SongList>         SongLists         { get { return this.GetTable<SongList>(); } }
		public ITable<SongListDetail>   SongListDetails   { get { return this.GetTable<SongListDetail>(); } }
		public ITable<SysShopDetail>    SysShopDetails    { get { return this.GetTable<SysShopDetail>(); } }
		public ITable<SysShopInfo>      SysShopInfo       { get { return this.GetTable<SysShopInfo>(); } }
		public ITable<SysUser>          SysUsers          { get { return this.GetTable<SysUser>(); } }

		public DbDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public DbDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public DbDB(LinqToDBConnectionOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public DbDB(LinqToDBConnectionOptions<DbDB> options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table("account_area")]
	public partial class AccountArea
	{
		[Column("id"),    PrimaryKey,  NotNull] public int    Id    { get; set; } // int
		[Column("name"),     Nullable         ] public string Name  { get; set; } // varchar(50)
		[Column("pid"),                NotNull] public int    Pid   { get; set; } // int
		[Column("level"),              NotNull] public int    Level { get; set; } // int
	}

	[Table("AI_VOCABULARY")]
	public partial class AiVocabulary
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column(),                       Nullable         ] public string    QUESTION         { get; set; } // longtext
		[Column(),                       Nullable         ] public string    ANSWER1          { get; set; } // longtext
		[Column(),                       Nullable         ] public string    ANSWER2          { get; set; } // longtext
		[Column(),                       Nullable         ] public string    ANSWER3          { get; set; } // longtext
	}

	[Table("ARTICLE")]
	public partial class ARTICLE
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column("ARTICLE_CODE"),                   NotNull] public string    ArticleCode      { get; set; } // varchar(80)
		[Column("ARTICLE_NAME"),                   NotNull] public string    ArticleName      { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public string    CONTENT          { get; set; } // longtext
		[Column("IMG_CODE"),             Nullable         ] public string    ImgCode          { get; set; } // varchar(80)
		/// <summary>
		/// 文章分类
		/// </summary>
		[Column("ARTICLE_CATEGORY"),     Nullable         ] public string    ArticleCategory  { get; set; } // varchar(80)
		[Column("LAST_ESSAY"),           Nullable         ] public string    LastEssay        { get; set; } // varchar(100)
		[Column("NEXT_ESSAY"),           Nullable         ] public string    NextEssay        { get; set; } // varchar(100)
	}

	[Table("ARTICLE_CATEGORY")]
	public partial class ArticleCategory
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // date
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // date
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column("CATEGORY_CODE"),                  NotNull] public string    CategoryCode     { get; set; } // varchar(80)
		[Column("CATEGORY_NAME"),                  NotNull] public string    CategoryName     { get; set; } // varchar(80)
	}

	[Table("CHAT_RECORD")]
	public partial class ChatRecord
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("GROUP_ID"),             Nullable         ] public string    GroupId          { get; set; } // varchar(80)
		[Column("CHAR_RECORD"),          Nullable         ] public string    CharRecord       { get; set; } // longtext
	}

	[Table("CLIENT_VERSION")]
	public partial class ClientVersion
	{
		[PrimaryKey, NotNull] public string   ID       { get; set; } // varchar(80)
		[Column,     NotNull] public DateTime DATETIME { get; set; } // datetime
		[Column,     NotNull] public string   CLIENT   { get; set; } // varchar(255)
		[Column,     NotNull] public string   VERSION  { get; set; } // varchar(255)
		[Column,     NotNull] public string   PATH     { get; set; } // text
	}

	[Table("CLOUD_STORAGE")]
	public partial class CloudStorage
	{
		[PrimaryKey, NotNull    ] public string   ID       { get; set; } // varchar(120)
		[Column,        Nullable] public string   CONTENT  { get; set; } // text
		[Column,     NotNull    ] public string   USER     { get; set; } // varchar(120)
		[Column,     NotNull    ] public DateTime DATETIME { get; set; } // datetime
	}

	[Table("EMOJI")]
	public partial class EMOJI
	{
		[Column(),                    NotNull    ] public string    ID               { get; set; } // varchar(32)
		[Column("DATETIME_CREATED"),  NotNull    ] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),      NotNull    ] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                    NotNull    ] public char      STATE            { get; set; } // char(1)
		[Column("GROUP_ID"),             Nullable] public string    GroupId          { get; set; } // varchar(80)
		[Column(),                       Nullable] public string    URLS             { get; set; } // longtext
	}

	[Table("FOOD_IMAGES")]
	public partial class FoodImage
	{
		[Column(),                    NotNull    ] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),  NotNull    ] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),      NotNull    ] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable] public char?     STATE            { get; set; } // char(1)
		[Column("SHOP_DETAIL_ID"),    NotNull    ] public string    ShopDetailId     { get; set; } // varchar(80)
		[Column(),                    NotNull    ] public string    URL              { get; set; } // text
	}

	[Table("GROUPS")]
	public partial class GROUP
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(32)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column("GROUP_ID"),             Nullable         ] public string    GroupId          { get; set; } // varchar(80)
		[Column("GROUP_NAME"),           Nullable         ] public string    GroupName        { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public string    USERS            { get; set; } // longtext
	}

	[Table("I_LIKE")]
	public partial class ILike
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column("MUSIC_NAME"),                     NotNull] public string    MusicName        { get; set; } // varchar(80)
		[Column("USER_CODE"),                      NotNull] public string    UserCode         { get; set; } // varchar(80)
	}

	[Table("IMAGE")]
	public partial class IMAGE
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // date
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column("IMG_CODE"),             Nullable         ] public string    ImgCode          { get; set; } // varchar(80)
		[Column("IMG_BASE64"),           Nullable         ] public string    ImgBASE64        { get; set; } // longtext
	}

	[Table("LYRICS")]
	public partial class LYRIC
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("MUSIC_ID"),                       NotNull] public string    MusicId          { get; set; } // varchar(80)
		[Column("LYRIC"),                Nullable         ] public string    LYRICColumn      { get; set; } // longtext
	}

	[Table("MUSICS")]
	public partial class MUSIC
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("MUSIC_NAME"),                     NotNull] public string    MusicName        { get; set; } // varchar(80)
		[Column(),                                 NotNull] public string    ARTISTS          { get; set; } // varchar(80)
		[Column(),                                 NotNull] public string    QUALITY          { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public string    CDN              { get; set; } // text
		[Column(),                       Nullable         ] public string    ALBUM            { get; set; } // varchar(200)
		[Column(),                       Nullable         ] public byte[]    LYRIC            { get; set; } // longblob
	}

	[Table("MUSIC_INFO")]
	public partial class MusicInfo
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column("singer_name"),          Nullable         ] public string    SingerName       { get; set; } // text
		[Column("song_name"),            Nullable         ] public string    SongName         { get; set; } // text
		[Column("subtitle"),             Nullable         ] public string    Subtitle         { get; set; } // text
		[Column("album_name"),           Nullable         ] public string    AlbumName        { get; set; } // text
		[Column("singer_id"),            Nullable         ] public string    SingerId         { get; set; } // text
		[Column("singer_mid"),           Nullable         ] public string    SingerMid        { get; set; } // longtext
		[Column("song_time_public"),     Nullable         ] public string    SongTimePublic   { get; set; } // varchar(200)
		[Column("song_type"),            Nullable         ] public string    SongType         { get; set; } // varchar(200)
		[Column("language"),             Nullable         ] public string    Language         { get; set; } // varchar(200)
		[Column("song_id"),              Nullable         ] public string    SongId           { get; set; } // varchar(200)
		[Column("song_mid"),             Nullable         ] public string    SongMid          { get; set; } // varchar(50)
		[Column("song_url"),             Nullable         ] public string    SongUrl          { get; set; } // text
		[Column("lyric"),                Nullable         ] public string    Lyric            { get; set; } // longtext
	}

	[Table("NETDISK_FILE_INFO")]
	public partial class NetdiskFileInfo
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public string    PATH             { get; set; } // varchar(255)
		[Column("FILE_NAME"),            Nullable         ] public string    FileName         { get; set; } // varchar(555)
		[Column("EXTENSION_NAME"),       Nullable         ] public string    ExtensionName    { get; set; } // varchar(255)
		[Column("DATETIME_CREATED"),     Nullable         ] public DateTime? DatetimeCreated  { get; set; } // datetime
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
	}

	[Table("NEWEST_CHAT_RECORD")]
	public partial class NewestChatRecord
	{
		[Column(),                     NotNull    ] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),   NotNull    ] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),       NotNull    ] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),     Nullable] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),         Nullable] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                     NotNull    ] public char      STATE            { get; set; } // char(1)
		[Column("GROUP_ID"),              Nullable] public string    GroupId          { get; set; } // varchar(80)
		[Column("NEWEST_CHAR_RECORD"),    Nullable] public string    NewestCharRecord { get; set; } // longtext
	}

	[Table("PLAY_COUNT")]
	public partial class PlayCount
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("MUSIC_ID"),                       NotNull] public string    MusicId          { get; set; } // varchar(80)
		[Column(),                                 NotNull] public decimal   QTY              { get; set; } // decimal(18,0)
	}

	[Table("SONG_LIST")]
	public partial class SongList
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("LIST_NAME"),                      NotNull] public string    ListName         { get; set; } // varchar(200)
		[Column(),                       Nullable         ] public string    IMG              { get; set; } // text
	}

	[Table("SONG_LIST_DETAIL")]
	public partial class SongListDetail
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("LIST_ID"),                        NotNull] public string    ListId           { get; set; } // varchar(80)
		[Column("MUSIC_ID"),                       NotNull] public string    MusicId          { get; set; } // varchar(80)
	}

	[Table("SYS_SHOP_DETAIL")]
	public partial class SysShopDetail
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("SHOP_ID"),                        NotNull] public string    ShopId           { get; set; } // varchar(80)
		[Column("FOOD_NAME"),                      NotNull] public string    FoodName         { get; set; } // text
		[Column(),                                 NotNull] public decimal   SCORE            { get; set; } // decimal(18,1)
	}

	[Table("SYS_SHOP_INFO")]
	public partial class SysShopInfo
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // datetime
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // datetime
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public char?     STATE            { get; set; } // char(1)
		[Column("SHOP_NAME"),                      NotNull] public string    ShopName         { get; set; } // text
		[Column("ENVIRONMENT_SCORE"),              NotNull] public decimal   EnvironmentScore { get; set; } // decimal(18,0)
		[Column("OTHER_SCORE"),                    NotNull] public decimal   OtherScore       { get; set; } // decimal(18,0)
	}

	[Table("SYS_USER")]
	public partial class SysUser
	{
		[Column(),                    PrimaryKey,  NotNull] public string    ID               { get; set; } // varchar(80)
		[Column("DATETIME_CREATED"),               NotNull] public DateTime  DatetimeCreated  { get; set; } // date
		[Column("USER_CREATED"),                   NotNull] public string    UserCreated      { get; set; } // varchar(80)
		[Column("DATETIME_MODIFIED"),    Nullable         ] public DateTime? DatetimeModified { get; set; } // date
		[Column("USER_MODIFIED"),        Nullable         ] public string    UserModified     { get; set; } // varchar(80)
		[Column(),                                 NotNull] public char      STATE            { get; set; } // char(1)
		[Column("USER_NAME"),            Nullable         ] public string    UserName         { get; set; } // varchar(80)
		[Column("DISPLAY_NAME"),         Nullable         ] public string    DisplayName      { get; set; } // varchar(80)
		[Column("PARENT_NAME"),          Nullable         ] public string    ParentName       { get; set; } // varchar(80)
		[Column(),                       Nullable         ] public string    PASSWORD         { get; set; } // varchar(50)
		[Column(),                       Nullable         ] public string    IMG              { get; set; } // longtext
	}

	public static partial class TableExtensions
	{
		public static AccountArea Find(this ITable<AccountArea> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static AiVocabulary Find(this ITable<AiVocabulary> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static ARTICLE Find(this ITable<ARTICLE> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static ArticleCategory Find(this ITable<ArticleCategory> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static ChatRecord Find(this ITable<ChatRecord> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static ClientVersion Find(this ITable<ClientVersion> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static CloudStorage Find(this ITable<CloudStorage> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static GROUP Find(this ITable<GROUP> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static ILike Find(this ITable<ILike> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static IMAGE Find(this ITable<IMAGE> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static LYRIC Find(this ITable<LYRIC> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static MUSIC Find(this ITable<MUSIC> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static MusicInfo Find(this ITable<MusicInfo> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static NetdiskFileInfo Find(this ITable<NetdiskFileInfo> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static PlayCount Find(this ITable<PlayCount> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static SongList Find(this ITable<SongList> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static SongListDetail Find(this ITable<SongListDetail> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static SysShopDetail Find(this ITable<SysShopDetail> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static SysShopInfo Find(this ITable<SysShopInfo> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static SysUser Find(this ITable<SysUser> table, string ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}
	}
}