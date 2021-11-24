using System.ComponentModel.Composition;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Trinity.VSExtension.EditorExtension.SyntaxHighlighting
{
    [Guid("16AA2022-E3D5-4DD8-BCCA-5F3384C5A357")]
    internal static class SyntaxHighlightClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("TSLClassifierType_Atom")]
        internal static ClassificationTypeDefinition TSLClassifierType_Atom = null;
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("TSLClassifierType_Keyword")]
        internal static ClassificationTypeDefinition TSLClassifierType_Keyword = null;
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("TSLClassifierType_Modifier")]
        internal static ClassificationTypeDefinition TSLClassifierType_Modifier = null;
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("TSLClassifierType_Container")]
        internal static ClassificationTypeDefinition TSLClassifierType_Container = null;
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("TSLClassifierType_Comment")]
        internal static ClassificationTypeDefinition TSLClassifierType_Comment = null;
    }
}
