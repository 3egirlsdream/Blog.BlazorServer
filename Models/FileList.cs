using BlogBlazorServer.Enums;

namespace BlogBlazorServer.Models
{
    public class FileList
    {
        public string Id { get; set; }
        /// <summary>
        /// 文件/文件夹名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 图标名
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DatetimeCreated { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime DatetimeModified { get; set; }
        /// <summary>
        /// 文件/文件夹大小
        /// </summary>
        public decimal Size { get; set; }
        /// <summary>
        /// 文件夹还是文件
        /// </summary>
        public FileFolderEnum Type { get; set; }
        /// <summary>
        /// MD5
        /// </summary>
        public string MD5 { get; set; }

        public HashSet<FileList> Children { get; set; }
    }
}
