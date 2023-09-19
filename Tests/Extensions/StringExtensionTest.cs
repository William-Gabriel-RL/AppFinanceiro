using CrossCutting.Extensions;

namespace Tests.Extensions
{
    public class StringExtensionTest
    {
        readonly string validCnpj = "69458316000128";
        readonly string validCpf = "35593570043";
        readonly string invalidCnpj = "11111111111111";
        readonly string invalidCpf = "00000000000";
        public string text = "1bcs23as45asxc-6!7@-;8\\9aioj0";


        [Fact]
        public void IsValidCNPJTest()
        {
            Assert.True(validCnpj.IsValidCNPJ());
            Assert.False(invalidCnpj.IsValidCNPJ());
        }

        [Fact]
        public void IsValidCPFTest()
        {
            Assert.True(validCpf.IsValidCPF());
            Assert.False(invalidCpf.IsValidCPF());
        }

        [Fact]
        public void ExtractNumbersTest()
        {
            Assert.Equal("1234567890", text.ExtractNumbers());
        }
    }
}