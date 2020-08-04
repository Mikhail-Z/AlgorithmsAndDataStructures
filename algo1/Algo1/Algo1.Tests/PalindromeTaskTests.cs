using System;
using NUnit.Framework;
using AlgorithmsDataStructuresTasks;

namespace AlgorithmsDataStructuresTests
{
    public class PalindromeUnitTests
    {
        [Test]
        public void Test_Check_WhenStringIsPalindromeEvenSize()
        {
            var s = "abccba";
            var isPalindrome = Palindrome.Check(s);
            Assert.AreEqual(true, isPalindrome);
        }

        [Test]
        public void Test_Check_WhenStringIsPalindromeOddSize()
        {
            var s = "abcba";
            var isPalindrome = Palindrome.Check(s);
            Assert.AreEqual(true, isPalindrome);
        }

        [Test]
        public void Test_Check_WhenStringIsNotPalindromeEvenSize()
        {
            var s = "abccda";
            var isPalindrome = Palindrome.Check(s);
            Assert.AreEqual(false, isPalindrome);
        }

        [Test]
        public void Test_Check_WhenStringIsNotPalindromeOddSize()
        {
            var s = "abcda";
            var isPalindrome = Palindrome.Check(s);
            Assert.AreEqual(false, isPalindrome);
        }
    }
}