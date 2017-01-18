using SX.WebCore.ViewModels;

namespace simlex.ViewModels
{
    public sealed class VMMaterialsStatisticBlock
    {
        public VMMaterialsStatisticBlock()
        {
            CommentedMaterials = new VMMaterial[0];
            Materials = new VMMaterial[0];
            Tags = new SxVMMaterialTag[0];
        }

        public VMMaterial[] CommentedMaterials { get; set; }
        public VMMaterial[] Materials { get; set; }
        public SxVMMaterialTag[] Tags { get; set; }
    }
}