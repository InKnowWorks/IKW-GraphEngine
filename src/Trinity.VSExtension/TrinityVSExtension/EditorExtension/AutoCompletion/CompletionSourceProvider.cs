using System.Text;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;
using Trinity.VSExtension.EditorExtension.TSL;
using System.Runtime.InteropServices;

namespace Trinity.VSExtension.EditorExtension.AutoCompletion
{
    [Export(typeof(ICompletionSourceProvider))]
    [ContentType("TrinitySpecificationLanguage")]
    [Name("TSLCompletionSourceProvider")]
    [Guid("AE63C391-7189-4367-8B76-9BFCA3CCCBAB")]
    internal class CompletionSourceProvider : ICompletionSourceProvider
    {
        [Import]
        internal ITextStructureNavigatorSelectorService NavigatorService { get; set; }
        [Import]
        internal IGlyphService GlyphService { get; set; }

        public ICompletionSource TryCreateCompletionSource(ITextBuffer textBuffer)
        {
            //return new DumbCompletionSource(this, textBuffer);
            if (!TSLParser.Ready)
                return null;
            return new CompletionSource(this, textBuffer);
        }
    }
}
