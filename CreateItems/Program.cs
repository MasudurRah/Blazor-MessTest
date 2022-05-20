using System;
using System.Collections.Generic;
using System.Linq;
using blazorTest.Shared;
using System.Text.Json;
using System.IO;

namespace CreateItems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Creating 5000 Generic Person Records...");
            var people = new List<Person>();

            for (int i = 0; i < 5000; i++)
            {
                var person = new Person();
                person.Id = i + 1;
                person.FirstName = LoremIpsum.Generate(1);
                person.LastName = LoremIpsum.Generate(1);
                person.Bio = LoremIpsum.Generate(50, 50);

                // clean up text
                person.FirstName = Capitalize(Clean(person.FirstName));
                person.LastName = Capitalize(Clean(person.LastName));
                person.Bio = Capitalize(person.Bio);

                people.Add(person);
            }


            // Serialize
            var json = JsonSerializer.Serialize(people);

            // Save to file
            string filename = $"{Environment.CurrentDirectory}\\people.json";
            if (File.Exists(filename))
                File.Delete(filename);

            File.WriteAllText(filename, json);

            Console.WriteLine("Done.");
        }

        static string Clean(string text)
        {
            var value = text.Trim();
            if (value.EndsWith(".") || value.EndsWith(","))
            {
                value = value.Substring(0, value.Length - 1);
            }
            return value;
        }
        static string Capitalize(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1);
        }
    }

    /// <summary>
    /// Borrowed and modified from https://archive.codeplex.com/?p=loremipsumhelper
    /// </summary>
    public class LoremIpsum
    {
        public static string Generate(uint iWordNumber = 300, uint iParagraphLength = 100)
        {
            try
            {
                if (iWordNumber > 600) throw new Exception("Word number to big, must be less than 600");
                if (iParagraphLength > 600) throw new Exception("Paragraph length is to high, must be less that 600");
                if (iParagraphLength <= 0) throw new Exception("Paragraph length is to low, must be at least 1");
                // text to be outputed
                var aText = RandomStringArrayTool.RandomizeStrings(aLoremIspumArray);
                var sText = "";
                // generate text with 100 words paragraphs.
                for (var i = 0; i < iWordNumber; i++)
                {
                    // append an loremipsum paragraph word to sText
                    sText += aText[i] + " ";
                }

                return new string(sText).Trim();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        private static string sLoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a lorem arcu, et scelerisque magna. Aliquam commodo consectetur massa, at fermentum lorem pulvinar vel. Suspendisse sagittis condimentum nisi, id iaculis purus lacinia sit amet. Curabitur sed hendrerit quam. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Suspendisse id massa vel nunc vestibulum posuere et at dolor. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Proin accumsan vulputate arcu, et auctor nulla vestibulum id. Sed urna dolor, euismod non aliquam sit amet, sodales sed ante. Aliquam et nibh at felis tempus tempus. Nam ac risus id velit hendrerit venenatis. Nullam ut erat nisi, at porta ligula. Vestibulum a urna vitae risus ultrices iaculis varius ut erat. Donec et sapien mi. Maecenas sit amet lorem orci.Quisque nisl dolor, aliquam non ultricies vel, ornare eget odio. Quisque vulputate rutrum neque. Nunc ac metus a nisi ornare dapibus at ut urna. Nulla facilisi. Morbi arcu lorem, consectetur at accumsan nec, ultrices vel nunc. Nulla facilisi. Etiam quis eros tellus, non faucibus nibh. Sed id nulla dui. Proin vitae tortor lacus. Phasellus placerat sodales metus, at pellentesque felis luctus quis. Mauris feugiat dictum magna vitae mattis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas id arcu sapien. Fusce eu lorem hendrerit nunc sodales consectetur vel eget felis. Pellentesque consectetur molestie nulla ac ultricies. Phasellus facilisis justo et nisi consectetur lobortis. Aenean nisl est, pellentesque vel fermentum id, scelerisque sit amet augue.Donec non diam ac nisl tincidunt eleifend. Aliquam erat volutpat. Cras et urna id nibh porta sagittis nec in mauris. Nullam imperdiet tempor tempor. Nam ipsum quam, semper in vehicula ac, volutpat quis orci. Donec sollicitudin adipiscing mauris, ac cursus augue condimentum at. Morbi ac urna at lectus euismod porta vitae quis dui. In sagittis enim sit amet lacus dapibus sit amet tempus est cursus. Cras auctor semper nisl, at varius erat commodo in. Pellentesque pharetra nunc non risus laoreet sit amet hendrerit massa imperdiet. Ut cursus luctus enim et ultricies. Ut sed dui orci. Curabitur a nunc erat, at pulvinar sapien. Vestibulum sed nisl nisl. Suspendisse potenti. Mauris vitae aliquam velit. Ut id ligula sapien, vestibulum aliquet metus. Phasellus vulputate felis a felis porta at pretium lectus mattis. Maecenas erat augue, consectetur quis lacinia quis, euismod in dolor.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sit amet auctor massa. Nunc dapibus pellentesque faucibus. Vestibulum vitae mauris lorem. Nunc vitae dolor vel justo tempor lobortis. Nullam diam arcu, placerat et pulvinar sed, pulvinar commodo nulla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In nec nunc id quam ornare egestas. Maecenas sodales quam eget orci dignissim placerat. Nulla vel velit mi. Vestibulum id porta augue.Morbi ullamcorper aliquet quam id tristique. Aenean ultrices, mi sed tincidunt cursus, mi neque feugiat neque, sit amet consequat nibh ante et neque. Integer nisi nibh, interdum ullamcorper rutrum sit amet, faucibus ac ligula. Nullam non leo elit, in euismod nulla. Mauris diam leo, cursus at eleifend sed, rhoncus vel massa. In pretium erat purus, a imperdiet elit. Morbi dictum quam vitae tellus aliquam quis euismod mauris ultricies. Mauris nec nulla nisi. Etiam in purus et tortor sollicitudin adipiscing gravida in ligula. Maecenas molestie sem vitae elit hendrerit suscipit. Nulla pretium, nulla sed rhoncus dictum, augue lacus rutrum urna, non semper felis felis vel mi. Suspendisse sed turpis risus. Pellentesque enim purus, semper sed viverra vel, pretium vel quam. Donec ultrices consectetur velit eu tristique. Vivamus mi risus, varius at lacinia eu, lobortis a purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum faucibus eros eu mattis.";
        private static string[] aLoremIspumArray = sLoremIpsum.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Slow but reliable method for randomizing string array
    /// </summary>
    static class RandomStringArrayTool
    {
        /// <summary>
        /// Stores the current random number
        /// </summary>
        static Random _random = new Random();

        /// <summary>
        /// Return randomized version of the string array
        /// </summary>
        public static string[] RandomizeStrings(string[] arr)
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            // Add all strings from array
            // Add new random int each time
            foreach (string s in arr)
            {
                list.Add(new KeyValuePair<int, string>(_random.Next(), s));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            string[] result = new string[arr.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        }
    }
}
