using System;
using System.IO;

namespace Task2
{
    class Task2
    {
        public struct Words_frequency
        {
            public string word;
            public int frequency;
        }
        static void Main(string[] args)
        {
            string Text = File.ReadAllText(@"C:\Users\gapta\source\repos\testTask2\Text.txt");
            int Text_length=Text.Length;
            string[] words=new string[500000];
            string[,] pages = new string[5000, 5000];
            string curr_word = "";
            int words_count = 0;
            int rows_count = 0;
            int page_count = 0;
            int words_in_page = 0;
            int i = 0;
        split_and_filter:
            if ((Text[i] >= 65) && (Text[i] <= 90) || (Text[i] >= 97) && (Text[i] <= 122))
            {
                if ((Text[i] >= 65) && (Text[i] <= 90))
                {
                    curr_word += (char)(Text[i] + 32);
                }
                else
                {
                    curr_word += Text[i];
                }
            }
            else
            {
                if (Text[i] == '\n') { rows_count++; }
                if (rows_count > 45)
                {
                    page_count++;
                    words_in_page = 0;
                    rows_count = 0;
                }
                if (curr_word != "" && curr_word != null && curr_word != "no" && curr_word != "from" && curr_word != "the" && curr_word != "by" && curr_word != "and" && curr_word != "i" && curr_word != "in" && curr_word != "or" && curr_word != "any" && curr_word != "for" && curr_word != "to" && curr_word != "\"" && curr_word != "a" && curr_word != "on" && curr_word != "of" && curr_word != "at" && curr_word != "is" && curr_word != "\n" && curr_word != "\r" && curr_word != "\r\n" && curr_word != "\n\r")
                {
                    words[words_count]=curr_word;
                    words_count++;
                    pages[page_count,words_in_page]=curr_word;
                    words_in_page++;
                }
                curr_word = "";
            }
            i++;
            if (i < Text_length) { goto split_and_filter; }
            else 
            {
                if (curr_word != "" && curr_word != null && curr_word != "no" && curr_word != "from" && curr_word != "the" && curr_word != "by" && curr_word != "and" && curr_word != "i" && curr_word != "in" && curr_word != "or" && curr_word != "any" && curr_word != "for" && curr_word != "to" && curr_word != "\"" && curr_word != "a" && curr_word != "on" && curr_word != "of" && curr_word != "at" && curr_word != "is" && curr_word != "\n" && curr_word != "\r" && curr_word != "\r\n" && curr_word != "\n\r")
                {
                    words[words_count] = curr_word;
                    words_count++;
                }
            }
            Words_frequency[] all_words=new Words_frequency[100000];
            int words_amount=words.Length;
            i = 0;
            int insert_position = 0;
            int all_dup_count = 0;
            int j;
        count_loop:
            j = 0;
            insert_position = 0;
            int curr_length = all_words.Length;
        words_scan_loop:
            if (j < curr_length && all_words[j].word != null)
            {
                if (all_words[j].word == words[i])
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
                all_words[i - all_dup_count].word = words[i];
                all_words[i - all_dup_count].frequency = 1;
            }
            else
            {
                all_words[insert_position].frequency += 1;
                all_dup_count++;
            }
            i++;
            if (i < words_amount && words[i] != null)
            {
                goto count_loop;
            }
            int all_words_count = all_words.Length;
            int k = 0;
            string[] less_100_words = new string[500000];
            int last_index = 0;
        less_100:
            if (k < all_words_count && all_words[k].word != null)
            {
                if (all_words[k].frequency <= 100)
                {
                    less_100_words[last_index] = all_words[k].word;
                    last_index++;
                }
                k++;
                goto less_100;
            }
            int write_index = 0;
            int sort_index = 0;
            bool swap=false;
            int curr_word_length = 0;
            int next_word_length = 0;
            int letter_counter = 0;
        sort:
            if (write_index < less_100_words.Length && less_100_words[write_index] != null)
            {
                sort_index = 0;
            sort_internal:
                if (sort_index < less_100_words.Length - write_index - 1 && less_100_words[sort_index + 1] != null)
                {
                    curr_word_length = less_100_words[sort_index].Length;
                    next_word_length = less_100_words[sort_index + 1].Length;
                    int compare_len= curr_word_length > next_word_length ? next_word_length : curr_word_length;
                    swap = false;
                    letter_counter = 0;
                alphabet:
                    if (less_100_words[sort_index][letter_counter] > less_100_words[sort_index + 1][letter_counter])
                    {
                        swap = true;
                        goto after_alphabet;
                    }
                    if (less_100_words[sort_index][letter_counter] < less_100_words[sort_index + 1][letter_counter])
                    {
                        goto after_alphabet;
                    }
                    letter_counter++;
                    if (letter_counter < compare_len) { goto alphabet; }
                after_alphabet:
                    if (swap)
                    {
                        string tmp = less_100_words[sort_index];
                        less_100_words[sort_index] = less_100_words[sort_index + 1];
                        less_100_words[sort_index + 1] = tmp;
                    }
                    sort_index++;
                    goto sort_internal;
                }
                write_index++;
                goto sort;
            }
            k = 0;
            int less_100_length=less_100_words.Length;
        print:
            if (k < less_100_length && less_100_words[k] != null)
            {
                Console.Write("{0} - ",less_100_words[k]);
                int pages_count = 0;
                int words_in_page_count = 0;
                int[] word_pages = new int[100];
                int curr_page = 0;
            page:
                if(pages_count<5000&&pages[pages_count,0] != null)
                {
                    words_in_page_count = 0;
                word_in_page:
                    if (words_in_page_count < 5000 && pages[pages_count, words_in_page_count] != null)
                    {
                        if(pages[pages_count,words_in_page_count] == less_100_words[k])
                        {
                            word_pages[curr_page] = pages_count + 1;
                            curr_page++;
                            pages_count++;
                            goto page;
                        }
                        words_in_page_count++;
                        goto word_in_page;
                    }
                    pages_count++;
                    goto page;
                }
                int page_counter = 0;
            page_output:
                if(page_counter<100&&word_pages[page_counter] != 0)
                {
                    if (page_counter != 99 && word_pages[page_counter + 1] != 0)
                    {
                        Console.Write("{0}, ",word_pages[page_counter]);
                    }
                    else
                    {
                        Console.Write("{0}", word_pages[page_counter]);
                    }
                    page_counter++;
                    goto page_output;
                }
                Console.WriteLine();
                k++;
                goto print;
            }
        }
    }
}