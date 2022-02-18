using System;
using System.IO;

namespace Task1
{
    
    class Task1
    {
        public struct Words_frequency
        {
            public string word;
            public int frequency;
        }
        static void Main(string[] args)
        {
            int Out_words_count = 25;
            string Text = File.ReadAllText(@"C:\Users\gapta\source\repos\testTask1\Text.txt");
            int text_length = Text.Length;
            string curr_word = "";
            string[] words = new string[100000];
            int words_count = 0;
            int i = 0;
        split_and_filter:
            if ((Text[i] >= 65) && (Text[i] <= 90) || (Text[i] >= 97) && (Text[i] <= 122) )
            {
                if ((Text[i] >= 65) && (Text[i] <= 90))
                {
                    curr_word+=(char)(Text[i]+32);
                }
                else
                {
                    curr_word+=Text[i];
                }
            }
            else
            {
                if (curr_word != "" && curr_word != null && curr_word != "-" && curr_word != "no" && curr_word != "from" && curr_word != "the" && curr_word != "by" && curr_word != "and" && curr_word != "i" && curr_word != "in" && curr_word != "or" && curr_word != "any" && curr_word != "for" && curr_word != "to" && curr_word != "\"" && curr_word != "a" && curr_word != "on" && curr_word != "of" && curr_word != "at" && curr_word != "is" && curr_word != "\n" && curr_word != "\r" && curr_word != "\r\n" && curr_word != "\n\r")
                {
                    words[words_count]=curr_word;
                    words_count++;
                }
                curr_word = "";
            }
            i++;
            if (i < text_length)
            {
                goto split_and_filter;
            }
            else
            {
                if (curr_word != "" && curr_word != null && curr_word != "-" && curr_word != "no" && curr_word != "from" && curr_word != "the" && curr_word != "by" && curr_word != "and" && curr_word != "i" && curr_word != "in" && curr_word != "or" && curr_word != "any" && curr_word != "for" && curr_word != "to" && curr_word != "\"" && curr_word != "a" && curr_word != "on" && curr_word != "of" && curr_word != "at" && curr_word != "is" && curr_word != "\n" && curr_word != "\r" && curr_word != "\r\n" && curr_word != "\n\r")
                {
                    words[words_count] = curr_word;
                    words_count++;
                }
            }
            Words_frequency[] unique_words = new Words_frequency[10000];
            int words_amount = words.Length;
            i = 0;
            int j = 0;
            int insert_position = 0;
            int all_dup_count = 0;
        count_loop:
            j = 0;
            insert_position = 0;
            int curr_length = unique_words.Length;
        words_scan_loop:
            if(j<curr_length && unique_words[j].word != null)
            {
                if (unique_words[j].word == words[i])
                {
                    insert_position = j;
                    goto after_scan_loop;
                }
                j++;
                goto words_scan_loop;
            }
        after_scan_loop:
            if (insert_position == 0)
            {
                unique_words[i - all_dup_count].word = words[i];
                unique_words[i - all_dup_count].frequency = 1;
            }
            else
            {
                unique_words[insert_position].frequency += 1;
                all_dup_count++;
            }
            i++;
            if(i<words_amount && words[i] != null)
            {
                goto count_loop;
            }
            int unique_words_length=unique_words.Length;
            j=0;
            int m = 0;
        sort_external:
            if (j < unique_words_length && unique_words[j].frequency != 0)
            {
                m = 0;
            sort_internal:
                if(m<unique_words_length-j-1&&unique_words[m].frequency != 0)
                {
                    if (unique_words[m].frequency < unique_words[m + 1].frequency)
                    {
                        Words_frequency temp = unique_words[m];
                        unique_words[m] = unique_words[m + 1];
                        unique_words[m + 1] = temp;
                    }
                    m++;
                    goto sort_internal;
                }
                j++;
                goto sort_external;
            }
            int k = 0;
        print:
            if (k < unique_words_length && unique_words[k].word!=null&& k < Out_words_count)
            {
                Console.WriteLine("{0} - {1}",unique_words[k].word,unique_words[k].frequency);
                k++;
                goto print;
            }
        }
    }
}
