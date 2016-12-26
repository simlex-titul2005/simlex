using SX.WebCore.ViewModels;

namespace simlex.ViewModels
{
    public sealed class MaterialsStatisticBlock
    {
        public MaterialsStatisticBlock()
        {
            Comments = new SxVMComment[0];
            Materials = new VMMaterial[0];
            Tags = new SxVMMaterialTag[0];
        }

        public SxVMComment[] Comments { get; set; }
        public VMMaterial[] Materials { get; set; }
        public SxVMMaterialTag[] Tags { get; set; }
    }
}