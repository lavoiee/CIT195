using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// I'm sacrificing eloquence for the ability to collapse each animation into its own function
    /// </summary>
    public static class Animations {

        /// <summary>
        /// Returns the width, height, and number of frames in the intro
        /// </summary>
        /// <returns></returns>
        public static int[] GetIntroSize() {
            int[] dimensions = new int[3];
            dimensions[0] = 100;    // Width
            dimensions[1] = 8;      // Height
            dimensions[2] = 53;     // Animation length
            return dimensions;
        }
        /// <summary>
        /// Returns a frame of the intro animation
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string[] GetIntro(int i) {
            string[] line = new string[8];
            if (i == -10) {
                //line[7] = @"1234567890123456789212345678931234567894123456789|                                                  ";
                line[0] = @"                                                                                                    ";
                line[1] = @"                                        /        _        \                                         ";
                line[2] = @"                                          /  o )   ( o  \                                           ";
                line[3] = @"                                          \     / \     /                                           ";
                line[4] = @"                                        \___           ___/                                         ";
                line[5] = @"                                            \         /                                             ";
                line[6] = @"                                             \       /                                              ";
                line[7] = @"                                                                                                   ";
            }
            if (i == -6) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                 .                                                                  ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                                                                                    ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == -5) {
                line[0] = @"                              _                                                                     ";
                line[1] = @"                                  -                                                                 ";
                line[2] = @"                      -                                                                             ";
                line[3] = @"                                                                                                    ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == -4) {
                line[0] = @"                               _   _                                                                ";
                line[1] = @"                                   _                                                                ";
                line[2] = @"                      __                                                                            ";
                line[3] = @"                                                                                                    ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == -3) {
                line[0] = @"                               __  __                                                               ";
                line[1] = @"                                   __                                                               ";
                line[2] = @"                      ___                                                                           ";
                line[3] = @"                                         _                                                          ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == -2) {
                line[0] = @"                                ___ __                                                              ";
                line[1] = @"                     -              _                                                               ";
                line[2] = @"                       ___                                                                          ";
                line[3] = @"                                         _\                                                         ";
                line[4] = @"                                        \                                                           ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == -1) {
                line[0] = @"                                 __ ___                                                             ";
                line[1] = @"                      -             __  /                                                           ";
                line[2] = @"                        ___                                                                         ";
                line[3] = @"                                          \_                                                        ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 0) {
                line[0] = @"                                 ______                                                             ";
                line[1] = @"                       _             _  /                                                           ";
                line[2] = @"                         ___                                                                        ";
                line[3] = @"                                          \__                                                       ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 1) {
                line[0] = @"                                  ______ _                                                          ";
                line[1] = @"                         -          ____/                                                           ";
                line[2] = @"                          _ _             /  c                                                      ";
                line[3] = @"                                          \_____/                                                   ";
                line[4] = @"                                        \                                                           ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                      _____                                                        ";
            }
            if (i == 2) {
                line[0] = @"                                   __    _                                                          ";
                line[1] = @"                                    ____/  _                                                        ";
                line[2] = @"                           _ _            /  o )                                                    ";
                line[3] = @"                                          \_ ___/                                                   ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                      _____                                                        ";
            }
            if (i == 3) {
                line[0] = @"                                    _     _                                                         ";
                line[1] = @"                                    . __/  _                                                        ";
                line[2] = @"                            . .           /  o )                                                    ";
                line[3] = @"                                          \_  __/                                                   ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                       _____                                                       ";
            }
            if (i == 4) {
                line[0] = @"                                    .     .                                                         ";
                line[1] = @"                                     _ _/_ __                                                       ";
                line[2] = @"                                          /  o )                                                    ";
                line[3] = @"                                          \__ __/ \                                                 ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                     -                                                              ";
                line[7] = @"                                         ___                                                       ";
            }
            if (i == 5) {
                line[0] = @"                               _         _                                                           ";
                line[1] = @"                                     _  /    __                                                     ";
                line[2] = @"                                             o )                                                    ";
                line[3] = @"                                          \_   _/ \_                                                ";
                line[4] = @"                                 _      \                                                           ";
                line[5] = @"                                      __                                                            ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                           _                                                       ";
            }
            if (i == 6) {
                line[0] = @"                               ___                                                                  ";
                line[1] = @"                                  -  .   _    _                                                     ";
                line[2] = @"                                          /  o )   (                                                ";
                line[3] = @"                                            _   / \ _                                               ";
                line[4] = @"                                 __     \                                                           ";
                line[5] = @"                                      _____                                                         ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                           -                                                       ";
            }
            if (i == 7) {
                line[0] = @"                               ______    _                                                          ";
                line[1] = @"                                  ----  /           _                                               ";
                line[2] = @"                                             o )   ( c                                              ";
                line[3] = @"                                                  \  _                                              ";
                line[4] = @"                                 ____                                                               ";
                line[5] = @"                                      _______                                                       ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 8) {
                line[0] = @"                                _ ____                                                              ";
                line[1] = @"                                   -----/           __                                              ";
                line[2] = @"                                                   ( o                                              ";
                line[3] = @"                                                     __                                             ";
                line[4] = @"                                 _______                                                            ";
                line[5] = @"                                      __ ______                                                     ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 9) {
                line[0] = @"                                __  ___                                                             ";
                line[1] = @"                                   -  --/-          __                                              ";
                line[2] = @"                                                   ( o                                              ";
                line[3] = @"                                                      __                                            ";
                line[4] = @"                                  _ ______                                                          ";
                line[5] = @"                                       _   ____                                                     ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 10) {
                line[0] = @"                                  - _____                                                           ";
                line[1] = @"                                    -   /   -         __                                            ";
                line[2] = @"                                                     o  \                                           ";
                line[3] = @"                                                       __                                           ";
                line[4] = @"                                   __  ___                                                          ";
                line[5] = @"                                        _    ___                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 11) {
                line[0] = @"                                   '  ----                                                          ";
                line[1] = @"                                     '  /'   '         _                                            ";
                line[2] = @"                                                        \                                           ";
                line[3] = @"                                          \             __/                                         ";
                line[4] = @"                                   ___ ____                                                         ";
                line[5] = @"                                        -   -----                                                   ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 12) {
                line[0] = @"                                    `   '``                                                         ";
                line[1] = @"                                      `   `   `                                                     ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                          \              _/                                         ";
                line[4] = @"                                   ____ _-_                                                         ";
                line[5] = @"                                         '     ---                                                  ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 13) {
                line[0] = @"                                            -  _                                                    ";
                line[1] = @"                                          `                                                         ";
                line[2] = @"                                                          \                                         ";
                line[3] = @"                                          \               /                                         ";
                line[4] = @"                                    __  _~-_                                                        ";
                line[5] = @"                                                 '                                                  ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 14) {
                line[0] = @"                                               `                                                    ";
                line[1] = @"                                                         _                                          ";
                line[2] = @"                                                          \                                         ";
                line[3] = @"                                         _                                                          ";
                line[4] = @"                                    .   - '-      _                                                 ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 15) {
                line[0] = @"                                              -                                                     ";
                line[1] = @"                                                         _                                          ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                         |                                                          ";
                line[4] = @"                                        ' `       .                                                 ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 16) {
                line[0] = @"                                              .                                                     ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                         |_                                                         ";
                line[4] = @"                                                  .                                                 ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 17) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                              '                                                     ";
                line[2] = @"                                                      _                                             ";
                line[3] = @"                                         |\                                                         ";
                line[4] = @"                                                  '                                                 ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 18) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                              .                                                     ";
                line[2] = @"                                                      __                                            ";
                line[3] = @"                                         |.L      .                                                 ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 19) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                              |       ___                                           ";
                line[3] = @"                                         N_       _                                                 ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 20) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                       _ _                                          ";
                line[3] = @"                                         N_   !   _                                                 ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 21) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                         Ni_  !   _    ` '                                          ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 22) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                         Nr_  /\ _-_   .T                                           ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 23) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                         NC|_ M_ = _x  _Y                                           ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 24) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N<E C M |-A   _.Y                                           ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 25) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N=E C MR  A  |\ Y                                           ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 26) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N_E.C RM _A N|  Y                                           ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 27) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R=M__A NL Y                                           ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 28) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C ROM_-A Nc Y                                           ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 29) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C ROM--A N n-<                                          ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 30) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R-OM-A N c-<                                          ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 31) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R--OMA N c Y                                          ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 32) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R  _-0MAN n Y                                         ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 33) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R _o MA N c Y                                         ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 34) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R o M A N C Y                                         ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 35) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R 0 M A N C Y                                         ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 36) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                        N E C R O M A N C Y                                         ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 38) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                                                                                    ";
                line[3] = @"                                       N E C R ( ) M A N C Y                                         ";
                line[4] = @"                                                                                                    ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 40) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                       _       _                                                    ";
                line[3] = @"                                  |\| |- ( |; (_) |\/| /\ |\| ( V                                   ";
                line[4] = @"                                       `                                                            ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 41) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                                   __, _  .-.  ..        _       _                                  ";
                line[3] = @"                               |\| |- (   |-/ (__) |\/| |_| |\| ( ` V                               ";
                line[4] = @"                                   `'' '' ' `      '  ' ' ' ' '  `' '                               ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 42) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                           . . __, .-. .--.  .-.  __  _   _       .-. . .                           ";
                line[3] = @"                           |\| |_ (    |--/ (._.) | \/ | /_| |\| (     V                            ";
                line[4] = @"                           ! V |_, `-- !  \  \_/  ! !  ! | | ! V  `--  |                            ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 43) {
                line[0] = @"                                                                                                    ";
                line[1] = @"                                                                                                    ";
                line[2] = @"                 |\  |  \``'  /``'\  /```|  /```\   |\  /|  |\    |\  |   /``\  \ /                 ";
                line[3] = @"                 | \ |  |--  |       |--/  |     |  | \.'|  |_\   | | |  |       Y                  ";
                line[4] = @"                 |  \|  /..,  \___,  |   \  \._./   | |  | /   |  |  \|   \...   |                  ";
                line[5] = @"                                                                                                    ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 44) {
                line[0] = @"                                                                                                    ";
                line[1] = @"          .   .  .....-   .,--.   .--.     _.-..    ..    ,    .    ,   ,    .,--'!  ..   .         ";
                line[2] = @"          |\  |  |      /'     '  |   || ./     ||  |\  /|    /|\   |\  |   //        \\ /          ";
                line[3] = @"          | \ |  |--|   |         |--//  ||      || | \.'|   |  ||  | | |  ||          ||           ";
                line[4] = @"          |  \|  |      \.        |   \  '\.  ,-|/  | |  |  / ---|  |  \|   \          ||           ";
                line[5] = @"          '   '  '''''-  `----'   '   '    '''      ' '  '  '    '  '   '    `----'    ''           ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 45) {
                line[0] = @"                                                                                                    ";
                line[1] = @"     |    |  \|''''|   ..|'''.| i||''\.     .-..    |\    |     |    '|   '|'   ./|/'''! ||' '|     ";
                line[2] = @"     |i   |  ||  .   .|'     '  ||   ||  .|'    ||  |||  ||    |||    |!   |   //         || |      ";
                line[3] = @"     | \  |  ||''|   ||         ||''|/   ||      || |'|..'|   |  ||   | |  |  ||           ||       ";
                line[4] = @"     |  i!|  ||      '|.      . ||   |.  '|.    .|| | '|' |  .''''|   |  i!|   !.      .   ||       ";
                line[5] = @"     |    |  /|....|  ''|....'  !|.  '|'  ''|.'|    |' | '|  |'  '|.  |    |    '|'...'    ||       ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            if (i == 46) {
                line[0] = @"                                                                                                    ";
                line[1] = @"'|.   '|' '||''''|   ..|'''.| '||''|.     .|'||.  '||    |'     |     '|.   '|'   .||'''.| '||' '|' ";
                line[2] = @" |'|   |   ||  .   .|'     '   ||   ||  .|'    ||  |||  ||     |||     |'|   |  .||      '   || |   ";
                line[3] = @" | '|. |   ||''|   ||          ||''|'   ||      || |'|..'|    |  ||    | '|. |  ||            ||    ";
                line[4] = @" |   |||   ||      '|.      .  ||   |.  '|.     || | '|' |   .''''|.   |   |||  '|.      .    ||    ";
                line[5] = @".|.   '|  .||___.|  ''|.__.'  .||.  '|'  ''|_.|'  .|. | .|. .|.  .||. .|.   '|   ''|.__.'    .||.   ";
                line[6] = @"                                                                                                    ";
                line[7] = @"                                                                                                   ";
            }
            return line;
        }

        /// <summary>
        /// Returns the width, height, and number of frames in the intro
        /// </summary>
        /// <returns></returns>
        public static int[] GetItemPotionSize() {
            int[] dimensions = new int[3];
            dimensions[0] = 8;    // Width
            dimensions[1] = 5;      // Height
            dimensions[2] = 7;     // Animation length
            return dimensions;
        }
        /// <summary>
        /// Returns a frame of the intro animation
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string[] GetItemPotion(int i) {
            string[] line = new string[8];
            if (i == 0) {
                line[0] = @" ______ ";
                line[1] = @"|      |";
                line[2] = @"|  )(  |";
                line[3] = @"| (__) |";
                line[4] = @"|______|";
            }
            if (i == 1) {
                line[0] = @" ______ ";
                line[1] = @"|  .   |";
                line[2] = @"|  )(  |";
                line[3] = @"| (__) |";
                line[4] = @"|______|";
            }
            if (i == 2) {
                line[0] = @" ______ ";
                line[1] = @"|  o   |";
                line[2] = @"|  )(  |";
                line[3] = @"| (__) |";
                line[4] = @"|______|";
            }
            if (i == 3) {
                line[0] = @" ______ ";
                line[1] = @"|  °.  |";
                line[2] = @"|  )(  |";
                line[3] = @"| (__) |";
                line[4] = @"|______|";
            }
            if (i == 4) {
                line[0] = @" ______ ";
                line[1] = @"|  .°  |";
                line[2] = @"|  )(  |";
                line[3] = @"| (__) |";
                line[4] = @"|______|";
            }
            if (i == 5) {
                line[0] = @" ______ ";
                line[1] = @"|  O'  |";
                line[2] = @"|  )(  |";
                line[3] = @"| (__) |";
                line[4] = @"|______|";
            }
            if (i == 6) {
                line[0] = @" ______ ";
                line[1] = @"|  '   |";
                line[2] = @"|  )(  |";
                line[3] = @"| (__) |";
                line[4] = @"|______|";
            }
            return line;
        }

    }

    /*

    '|.   '|' '||''''|   ..|'''.| '||''|.     .|'||.  '||    |'     |     '|.   '|'   ./|'''.| '||' '|' 
     |'|   |   ||  .   .|'     '   ||   ||  .|'    ||  |||  ||     |||     |'|   |  .|/      '   || |   
     | '|. |   ||''|   ||          ||''|'   ||      || |'|..'|    |  ||    | '|. |  ||            ||    
     |   |||   ||      '|.      .  ||   |.  '|.     || | '|' |   .''''|.   |   |||  '|.      .    ||    
    .|.   '|  .||___.|  ''|.__.'  .||.  '|'  ''|_.|'  .|. | .|. .|.  .||. .|.   '|   ''|.__.'    .||.  


    @@@  @@@  @@@@@@@@   @@@@@@@  @@@@@@@    @@@@@@   @@@@@@@@@@    @@@@@@   @@@  @@@  @@@@@@@  @@@ @@@ 
    @@!@!@@@  @@!       !@@       @@!  @@@  @@!  @@@  @@! @@! @@!  @@!  @@@  @@!@!@@@  !@@      @@! !@@ 
    @!@@!!@!  @!!!:!    !@!       @!@!!@!   @!@  !@!  @!! !!@ @!@  @!@!@!@!  @!@@!!@!  !@!       !@!@!  
    !!:  !!!  !!:       :!!       !!: :!!   !!:  !!!  !!:     !!:  !!:  !!!  !!:  !!!  :!!        !!:   
    ::    :   : :: ::    :: :: :   :   : :   : :. :    :      :     :   : :  ::    :   :: :: :    .:    
    */
}