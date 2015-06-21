using NUnit.Framework;

namespace CSharpFundamentals.Structures
{
    [TestFixture]
    public class Structures
    {
        public void UseStructure(EasyStructure structure)
        {
        }

        public struct EasyStructure
        {
            //cannot declare constructor with no parameters
            //            public EasyStructure()
            //            {
            //                
            //            }

            //cannot assign values to fields
            //            public int NumberValue = 4;

            //cannot create constructor where not every public field is initialised
            //            public EasyStructure(int id, int number, string text)
            //            {
            //                Id = id;
            //                Number = number;
            //            }

            public int Id;
            public int Number;
            public string Text;
        }

        public struct ComplicatedStructure
        {
            public ComplicatedStructure(string text, int number, string information)
            {
                Text = text;
                Number = number;
                Information = new Info() { Text = information };
            }

            public string Text;
            public int Number;
            public Info Information;

            public class Info
            {
                public string Text { get; set; }
            }
        }



        [Test]
        public void CreateStructure()
        {
            //allocates on stack with default values
            var structureOnHeap = new EasyStructure();
            UseStructure(structureOnHeap);
            Assert.That(structureOnHeap.Id, Is.EqualTo(0));
            Assert.That(structureOnHeap.Number, Is.EqualTo(0));
            //the default value for all reference types is null.
            Assert.That(structureOnHeap.Text, Is.Null);

            EasyStructure structureOnStack;
            //You cannot use EasyStructure until all its public fields are initialised
            //UseStructure(structureOnStack);
            structureOnStack.Number = 4;
            //UseStructure(structureOnStack);
            structureOnStack.Id = 4;
            structureOnStack.Text = "validString";
            UseStructure(structureOnStack);
        }

        [Test]
        public void GivenStruct_WhenStructIsCopied_ThenExpectNewStructCreatedOnStack_AndReferenceToTheSameObjectCopied()
        {
            var structure1 = new ComplicatedStructure("validString1", 1, "newValidInformation");
            var structure2 = structure1;

            structure2.Text = "validString2";
            structure2.Number = 10;
            structure2.Information.Text = "newValidInformation";

            Assert.That(structure1.Text, Is.EqualTo("validString1"));
            Assert.That(structure1.Number, Is.EqualTo(1));
            Assert.That(structure1.Information.Text, Is.EqualTo("newValidInformation"));

            Assert.That(structure2.Text, Is.EqualTo("validString2"));
            Assert.That(structure2.Number, Is.EqualTo(10));
            Assert.That(structure1.Information.Text, Is.EqualTo("newValidInformation"));

        }
    }
}