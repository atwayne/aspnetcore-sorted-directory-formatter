using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.AspNetCore.StaticFiles
{
    public class SortedHtmlDirectoryFormatter : HtmlDirectoryFormatter, IDirectoryFormatter
    {
        /// <summary>
        /// Constructs the <see cref="SortedHtmlDirectoryFormatter"/>.
        /// </summary>
        /// <param name="encoder">The character encoding representation to use.</param>
        public SortedHtmlDirectoryFormatter(HtmlEncoder encoder)
            : base(encoder)
        { }

        /// <summary>
        /// Constructs the <see cref="SortedHtmlDirectoryFormatter"/> with default encoder
        /// </summary>
        public SortedHtmlDirectoryFormatter()
            : base(HtmlEncoder.Default)
        { }

        public override Task GenerateContentAsync(HttpContext context, IEnumerable<IFileInfo> contents)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (contents == null)
            {
                throw new ArgumentNullException(nameof(contents));
            }

            var sortedContents = contents
                .OrderBy(content => content.IsDirectory)
                .ThenByDescending(content => content.LastModified);
            return base.GenerateContentAsync(context, sortedContents);
        }
    }
}