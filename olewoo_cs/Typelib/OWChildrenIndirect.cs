using System.Collections.Generic;

namespace Org.Benf.OleWoo.Typelib
{
    internal class OWChildrenIndirect : ITlibNode
    {
        private readonly string _name;
        private readonly dlgCreateChildren _genChildren;
        public OWChildrenIndirect(ITlibNode parent, string name, int imageidx, dlgCreateChildren genchildren)
        {
            Parent = parent;
            _name = name;
            ImageIndex = imageidx;
            _genChildren = genchildren;
        }
        public override string Name => _name;
        public override string ShortName => _name;
        public override string ObjectName => null;

        public override bool DisplayAtTLBLevel(ICollection<string> interfaceNames)
        {
            return true;
        }
        public override int ImageIndex { get; }
        public override ITlibNode Parent { get; }

        public override List<ITlibNode> GenChildren()
        {
            return _genChildren();
        }
        public override void BuildIDLInto(IDLFormatter ih)
        {
            Children.ForEach(x => x.BuildIDLInto(ih));
        }
    }
}