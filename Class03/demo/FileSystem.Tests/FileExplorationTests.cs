using System.IO;
using Xunit;

namespace FileSystem.Tests
{
    public class FileExplorationTests
    {
        [Theory]
        [InlineData("test.txt")]
        [InlineData("Assets/emoji-utf8.txt")]
        [InlineData("Assets/emoji-unicode.txt")]
        public void Can_find_emoji_file(string path)
        {
            // Arrange
            // from parameters

            // Act
            bool exists = File.Exists(path);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public void Can_read_emoji_file()
        {
            // Arrange
            string path = "Assets/emoji-utf8.txt";

            // Act
            string allText = File.ReadAllText(path);

            // Assert
            Assert.NotEmpty(allText);
        }

        [Fact]
        public void Can_read_lines_from_test_file()
        {
            // Arrange
            string path = "test.txt";

            // Act
            string[] lines = File.ReadAllLines(path);

            // Assert
            Assert.Equal(new[] { "Testing!" }, lines);
        }

        [Fact]
        public void Can_write_to_a_file()
        {
            // Arrange
            string path = "written-from-test.txt";
            string[] contents = new[] { "Hello!" };

            // Act
            File.WriteAllLines(path, contents);

            // Assert
            Assert.True(File.Exists(path));
            Assert.Equal(contents, File.ReadAllLines(path));

            // Cleanup
            File.Delete(path);

            // Assert again
            Assert.False(File.Exists(path));
        }

        [Fact]
        public void Can_append_to_a_file()
        {
            // Arrange
            string path = "append-to-me.txt";
            string[] initialContents = new[] { "First line" };

            File.WriteAllLines(path, initialContents);

            string valueToAppend = "Second line";

            // Act
            Program.AppendSingleLine(path, valueToAppend);

            // Assert
            string[] expectedContents = new[] { "First line", "Second line" };
            string[] actualContents = File.ReadAllLines(path);
            Assert.Equal(expectedContents, actualContents);
        }

        [Fact]
        public void Can_remove_line_from_file()
        {
            // Arrange
            string path = "Assets/remove-from-me.txt";
            File.WriteAllLines(path, new[] { "One", "Two", "Three" });

            // Act
            Program.RemoveLine(path, "Three");

            // Assert
            Assert.Equal(new[] { "One", "Two" }, File.ReadAllLines(path));
        }

        [Theory]
        [InlineData(new string[0], "Hello", new string[0])]
        [InlineData(new[] { "Hello" }, "Hello", new string[0])]
        [InlineData(new[] { "1", "2" }, "1", new[] { "2" })]
        [InlineData(new[] { "1", "2" }, "2", new[] { "1" })]
        [InlineData(new[] { "1", "2", "3" }, "1", new[] { "2", "3" })]
        [InlineData(new[] { "1", "2", "3" }, "2", new[] { "1", "3" })]
        [InlineData(new[] { "1", "2", "3" }, "3", new[] { "1", "2" })]
        [InlineData(new[] { "1", "2", "3" }, "0", new[] { "1", "2", "3" })]
        [InlineData(new[] { "1", "2", "1" }, "1", new[] { "2" })]
        [InlineData(new[] { "1", "1", "1" }, "1", new string[0])]
        public void Can_remove_from_array(string[] array, string value, string[] expected)
        {
            // Arrange
            // from parameters

            // Act
            string[] result = Program.RemoveItemFromArray(array, value);

            // Assert
            Assert.Equal(expected, result);
            Assert.NotSame(array, result);
        }
    }
}
