using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maruichi19gou.Adapters
{
    /// <summary>
    /// ファイルマージアダプター
    /// </summary>
    /// <remarks>
    /// ２個の入力ファイルをマージして出力ファイルを作成する
    /// </remarks>
    internal class FileMargeAdapter : IDisposable
    {
        /// <summary>
        /// 入力ファイル１
        /// </summary>
        internal string InputFile1Path { get; set; }
        /// <summary>
        /// 入力ファイル２
        /// </summary>
        internal string InputFile2Path { get; set; }
        /// <summary>
        /// 出力ファイル
        /// </summary>
        internal string OutputFilePath { get; set; }

        public void Dispose()
        {
            // No Action
        }

        /// <summary>
        /// 出力ファイル
        /// </summary>
        internal void Execute()
        {

        }
    }
}
