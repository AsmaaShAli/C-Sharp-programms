using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO_game
{
    class Program
    {
        static bool check_complete(ref char[,] matrix_xo)
        {
            bool complete = false;
            int count = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (matrix_xo[i, j] == 'X' || matrix_xo[i, j] == 'O')
                        count++;
                }

            if (count == 9)
                complete = true;

            return complete;
        }
        static bool check_diagonal(ref char[,] matrix_xo)
        {
            if ((matrix_xo[0, 0] == 'X' && matrix_xo[1, 1] == 'X' && matrix_xo[2, 2] == 'X') || (matrix_xo[0, 0] == 'O' && matrix_xo[1, 1] == 'O' && matrix_xo[2, 2] == 'O'))
                return true;
            else if ((matrix_xo[0, 2] == 'X' && matrix_xo[1, 1] == 'X' && matrix_xo[2, 0] == 'X') || (matrix_xo[0, 2] == 'O' && matrix_xo[1, 1] == 'O' && matrix_xo[2, 0] == 'O'))
                return true;
            else
                return false;
        }
        static bool check_columns(ref char[,] matrix_xo)
        {
            if ((matrix_xo[0, 0] == 'X' && matrix_xo[1, 0] == 'X' && matrix_xo[2, 0] == 'X') || (matrix_xo[0, 0] == 'O' && matrix_xo[1, 0] == 'O' && matrix_xo[2, 0] == 'O'))
                return true;
            else if ((matrix_xo[0, 1] == 'X' && matrix_xo[1, 1] == 'X' && matrix_xo[2, 1] == 'X') || (matrix_xo[0, 1] == 'O' && matrix_xo[1, 1] == 'O' && matrix_xo[2, 1] == 'O'))
                return true;
            else if ((matrix_xo[0, 2] == 'X' && matrix_xo[1, 2] == 'X' && matrix_xo[2, 2] == 'X') || (matrix_xo[0, 2] == 'O' && matrix_xo[1, 2] == 'O' && matrix_xo[2, 2] == 'O'))
                return true;
            else
                return false;
        }
        static bool check_rows(ref char[,] matrix_xo)
        {
            if ((matrix_xo[0, 0] == 'X' && matrix_xo[0, 1] == 'X' && matrix_xo[0, 2] == 'X') || (matrix_xo[0, 0] == 'O' && matrix_xo[0, 1] == 'O' && matrix_xo[0, 2] == 'O'))
                return true;
            else if ((matrix_xo[1, 0] == 'X' && matrix_xo[1, 1] == 'X' && matrix_xo[1, 2] == 'X') || (matrix_xo[1, 0] == 'O' && matrix_xo[1, 1] == 'O' && matrix_xo[1, 2] == 'O'))
                return true;
            else if ((matrix_xo[2, 0] == 'X' && matrix_xo[2, 1] == 'X' && matrix_xo[2, 2] == 'X') || (matrix_xo[2, 0] == 'O' && matrix_xo[2, 1] == 'O' && matrix_xo[2, 2] == 'O'))
                return true;
            else
                return false;
        }
        static bool check_win(ref char[,] matrix_xo)
        {
            if (check_columns(ref matrix_xo))
                return true;
            else if (check_rows(ref matrix_xo))
                return true;
            else if (check_diagonal(ref matrix_xo))
                return true;
            else
                return false;

        }
        static bool check_valid(int number)
        {
            bool valid = false;
            if (number == 1 || number == 2 || number == 3 || number == 4 || number == 5 || number == 6 || number == 7 || number == 8 || number == 9)
            {
                valid = true;
                return valid;
            }
            else
            {
                Console.WriteLine("\tSORRY,Please enter number from 1 to 9 only!\n");
                return valid;
            }
        }
        static bool check_duplicate(ref char[,] matrix_xo, int number)
        {
            bool duplicate = false;

            switch (number)
            {
                case 1:
                    if (matrix_xo[0, 0] == 'X' || matrix_xo[0, 0] == 'O')
                        duplicate = true;
                    break;
                case 2:
                    if (matrix_xo[0, 1] == 'X' || matrix_xo[0, 1] == 'O')
                        duplicate = true;
                    break;
                case 3:
                    if (matrix_xo[0, 2] == 'X' || matrix_xo[0, 2] == 'O')
                        duplicate = true;
                    break;
                case 4:
                    if (matrix_xo[1, 0] == 'X' || matrix_xo[1, 0] == 'O')
                        duplicate = true;
                    break;
                case 5:
                    if (matrix_xo[1, 1] == 'X' || matrix_xo[1, 1] == 'O')
                        duplicate = true;
                    break;
                case 6:
                    if (matrix_xo[1, 2] == 'X' || matrix_xo[1, 2] == 'O')
                        duplicate = true;
                    break;
                case 7:
                    if (matrix_xo[2, 0] == 'X' || matrix_xo[2, 0] == 'O')
                        duplicate = true;
                    break;
                case 8:
                    if (matrix_xo[2, 1] == 'X' || matrix_xo[2, 1] == 'O')
                        duplicate = true;
                    break;
                case 9:
                    if (matrix_xo[2, 2] == 'X' || matrix_xo[2, 2] == 'O')
                        duplicate = true;
                    break;
            }

            if (duplicate)
                Console.WriteLine("\tSORRY, your move is duplicated, Please enter a VALID one!");

            return duplicate;
        }

        static bool check_answer(char answer)
        {
            do
            {
                if (answer == 'Y' || answer == 'y')
                {
                    draw_matrix();
                    return true;
                }
                else if (answer == 'N' || answer == 'n')
                    return false;
                else if (answer == '0')
                    return true;
                else
                {
                    Console.WriteLine("Please enter a VALID answer chracter, y/n ONLY! ");
                    answer = Convert.ToChar(Console.ReadLine());
                }
            } while (true);
        }

        static void insert_char(ref char[,] matrix_xo, int cell_no, char x_o, ref xo_item[] xo_entries)
        {
            xo_entries[cell_no].position = cell_no;
            xo_entries[cell_no].value = x_o;

            switch (cell_no)
            {
                case 1:
                    matrix_xo[0, 0] = x_o;
                    break;
                case 2:
                    matrix_xo[0, 1] = x_o;
                    break;
                case 3:
                    matrix_xo[0, 2] = x_o;
                    break;
                case 4:
                    matrix_xo[1, 0] = x_o;
                    break;
                case 5:
                    matrix_xo[1, 1] = x_o;
                    break;
                case 6:
                    matrix_xo[1, 2] = x_o;
                    break;
                case 7:
                    matrix_xo[2, 0] = x_o;
                    break;
                case 8:
                    matrix_xo[2, 1] = x_o;
                    break;
                case 9:
                    matrix_xo[2, 2] = x_o;
                    break;

            }
        }

        static void draw_space()
        {
            for (int i = 1; i < 5; i++)
                Console.Write("    ");
        }
        static void draw_matrix()
        {
            int cell_no = 1;

            for (int i = 1; i < 16; i++)
            {
                draw_space();
                for (int j = 1; j < 30; j++)
                {
                    if (i % 5 == 0 && j % 10 == 0)
                        Console.Write("+");
                    else if (i % 5 == 0)
                        Console.Write("-");
                    else if (j % 10 == 0)
                        Console.Write("|");
                    else if ((i == 3 || i == 8 || i == 13) && j % 5 == 0)
                        Console.Write(cell_no++);
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
        static void draw_matrix(ref xo_item[] xo_entries)
        {
            //Console.Clear();
            int cell_no = 1;
            Console.Write("\n\n");
            for (int i = 1; i < 16; i++)
            {
                draw_space();
                for (int j = 1; j < 30; j++)
                {
                    if (i % 5 == 0 && j % 10 == 0)
                        Console.Write("+");
                    else if (i % 5 == 0)
                        Console.Write("-");
                    else if (j % 10 == 0)
                        Console.Write("|");
                    else if ((i == 3 || i == 8 || i == 13) && j % 5 == 0)
                    {

                        if (xo_entries[cell_no].value != 'a')
                            Console.Write(xo_entries[cell_no].value);
                        else
                            Console.Write(" ");


                        cell_no++;
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

        }

        static bool final_step(ref char[,] xo_matrix, ref char answer)
        {
            if (!check_win(ref xo_matrix))
            {
                if (check_complete(ref xo_matrix))
                {
                    Console.WriteLine("\tOOOPS,The matrix if FULL now.. No more moves are AVAILABLE \n    Do you care for another round, I don't mind beating you again :P !(Y/N)");
                    Console.Write("\t: ");
                    answer = Convert.ToChar(Console.ReadLine());
                    return true;
                }
                else
                    return false;
            }
            else
            {
                Console.WriteLine("                        ******CONGRATS*****           \n\t\t\t You have won this round \n   Do you care for another round, I don't mind beating you again ☻!(Y/N)");
                Console.Write("\t: ");
                answer = Convert.ToChar(Console.ReadLine());
                return true;
            }
        }

        static void reset_struct(ref xo_item[] xo_entries)
        {
            for (int i = 0; i < 10; i++)
            {
                xo_entries[i].value = 'a';
                xo_entries[i].position = 0;
            }
        }
        static void reset(ref char[,] game_matrix, ref int _X, ref int _O, ref char answer, ref xo_item[] xo_entries)
        {
            _X = 0;
            _O = 0;
            answer = '0';
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    game_matrix[i, j] = '0';
            reset_struct(ref xo_entries);
        }

        struct xo_item
        {
            public char value;
            public int position;
        };

        static void Main(string[] args)
        {
            char[,] game_matrix = new char[3, 3];
            xo_item[] xo = new xo_item[10];
            int _X = 0, _O = 0;
            char answer = '0';


            Console.WriteLine("\n ******** Welcome to XO Game, May the odds are always in your Favour ********");
            Console.WriteLine("\n\tHere is the matrix to Play :\n");
            draw_matrix();
            Console.WriteLine("Instructions: \n  1-The first player(X) enters the cell number in which he/she fill in matrix \n  2-The matrix will be drawn again after filling the cell with the X/O character  3-The game continues until it's WON or the matrix is COMPLETE ");
            Console.WriteLine("\n\tLETS PLAY\n");

            do
            {
                if (answer == 'y' || answer == 'Y')
                    reset(ref game_matrix, ref _X, ref _O, ref answer, ref xo);

                do
                {
                    Console.Write("    X Player, enter cell number: "); _X = Convert.ToInt32(Console.ReadLine());
                    //check validity of number to be 1..9 before drawing the matrix and accept it, also check wether it's duplicated or not.
                } while (!(!check_duplicate(ref game_matrix, _X) && check_valid(_X)));


                insert_char(ref game_matrix, _X, 'X', ref xo);
                draw_matrix(ref xo);

                if (final_step(ref game_matrix, ref answer))
                    continue;

                do
                {
                    Console.Write("    O Player, enter cell number: "); _O = Convert.ToInt32(Console.ReadLine());
                    //check validity of number to be 1..9 before drawing the matrix and accept it, also check wether it's duplicated or not.
                } while (!(!check_duplicate(ref game_matrix, _O) && check_valid(_O)));

                insert_char(ref game_matrix, _O, 'O', ref xo);
                Console.WriteLine();
                draw_matrix(ref xo);
                if (final_step(ref game_matrix, ref answer))
                    ;

            } while (check_answer(answer));

            Console.WriteLine("     It was a FUN time, hope to see you again soon   ");

        }
    }
}
