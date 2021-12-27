﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day05
{
    public static class Input
    {
        public static string Example = @"BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL";

        public static string Value = @"BBFBBBBRRL
FBFFFFBLRL
FBFBBFFRLR
FBFFFBFRLR
FFBBFFFLRR
FFBBBFFRRR
BFBBFBFLRL
BFFFBFFLRR
FBBBFFBLLR
BBFFBBFRRL
BFBBBBBRLR
FBBBBFFLLR
FFBFFFBLLR
FFBBFBFRRR
BBFBFFFRRR
FFBFFBBLLR
FBBFFBBLRL
FFBBBFBLLL
FFBFFBBLRR
FBFFBFBLLR
FFFBBBFLLL
BFBBFBFRLR
BBFBBBFLLL
FBBBFBBRLL
FFBBBBFRRL
BFBBBBFLRR
BBFBBFBLRL
FFBFFFBLRL
BFBBBBBRRR
FFFBFBFLLR
BFBFBBBLLR
FFBFBBBLRL
FFFBFBBLRR
BFFBFFFLLL
BFFFBFBLRL
BFBFFFBRLL
BBFFFFBRLR
FBBFFFBLRR
BFFFFBFLLL
BBBFFFFLLL
BFBFFBBRLL
BBFBFFFRRL
BFBBFFFRLR
BBFBFBFRRL
FBBFFBFRRL
BFBFBFFRRL
FFBFFFFLLR
FBBBFBBLLR
BBFFBFBRLL
BFFBFBBRLL
FBBFFFFRRR
BFFFBBBLRL
FFBBFFBLLL
FFFBBFFRRL
FBFBBBBLRR
FFBBBFFLLL
FBFBFFBRRR
FBBFFBBLLR
FBFFBFFRLL
BFBBBFFRLR
FBFFBBBLRR
FBFFFFBRLR
BBFFBBFLRL
FBFFBBFLRL
FBFBBFFRRR
BFBBBFBLRL
FBFBFFFLLR
FFFFBBBLLR
BFBFFBBLLR
BFFBBBFRLR
BFBBBFFLRR
BBFFFBBLLR
BFFFBBFLRL
FBFFBFBLRL
FBBBFFFRRL
FBFFFFBLLL
BFBFFBBRLR
BFBFBBBLRL
BFFBFBBRLR
FBBFBBBLLR
FFBFBFFRLL
FFFBBBBLRR
BFBFFFFLLL
BBFBFBBLLR
BFFFBBBRLR
FFBFFBFRLR
FBBFBBBLRL
BBFFFBBLLL
FFBFFBBRRR
FBBBBFBLLR
BBFBBFFRLL
BFBBBBFRLR
BBFBFFBRLR
FFBFFFFLLL
BBFBFBFRLL
FFBFFBBRLL
FBBFFFFRLR
FFBBBBBRRR
BBFFBBBLRL
BFFBBFBRLL
BFFFBBFRLL
BFFBFBFLRL
FBFFFFFRRR
BFFBFBBRRL
FBFBBBFLLR
FBFBFBBRLL
BBBFFFFRRR
BFBFBFFLRL
FFFFBFBRLL
FFBBFFBLRL
BBFFBFBLLL
BFFBBBBRLL
BFFBBBBRRR
BFBBBBFRRL
BBBFFFBLRL
FFBBFFFRRR
BFFFFFBRLR
FFFBBFBLLL
BFBFBBFRLR
FBBBFBFLRL
BFBFBFFRLR
BBFBBFFLRL
BFFFBFBLLL
BFFFFBBRLL
FFBFFFFRRL
BFFBFBBLLR
FFFFBBBLLL
FBBFFBBRRL
BFBFFFFLLR
FBFBFBFRLL
FBBBBBBLRR
BBFFFFBLRR
FFFFBFBRRR
FBBBBFBRLL
BBFBFBBLRR
FFBBFBFLLL
BFBBFFBLRL
FFFBBBBRRR
BFBBFFFRLL
BFBBBFBRRR
FFFFBBFRLR
FFBBFBFLRR
FFFFFBBLLR
BBFBBFBRLL
FBFBBBBRLR
BBFFFFBLRL
FBBFFFBLLR
FFBFFBBLLL
FFFBBBFLLR
FFFBBBFRRR
FFBBBFBRRR
FFFBBFFRRR
FFBBFFBLLR
BFBFFBFRRR
FFBFBBFLLR
BFFFFFFRRR
FFBFFBFLRL
BFFBFBBRRR
FBFBFFFRLL
BBBFFFBLLL
BFBBFBFRRL
BFFFFFBLRR
FBBBBBFRRR
FFBBBBFLRR
BBFBBBBLRR
BBFBFBFLLR
FFFFBBFRRR
FFBBBBBLLR
BFFFBFBRLR
FBBBFFBLLL
FFFFFFFRRR
FFFBFBFRRL
BFBBFBBLRR
FBBBBFBLRL
FBBBBFBRRR
BFFFFBFRRR
BFFBBFFLLL
FBBFBFBLRL
BFBBFFFRRL
FBFBFFBRLR
FBFFBFFLRR
BFFFBFBLLR
BFBBFFBRRR
BBFBBFBLLL
BFFBFFFLRR
FFFBBFFRLL
BFBBFFFLLL
BFFFBBBRLL
FBFFBBFRRR
FFBFBFBLLR
FBFFFFBLRR
FFBBFFFLLL
FFFBBBBRRL
BBFBFFFLLL
BBFFBBFLLR
BFBFBBBRRR
FBBBBFBRRL
FBFFFBFLLR
FBFBBBFRRR
BFFFBFBRRL
FBFBBBFLRL
BBFFBFFLRL
BBFBBFFLLR
FFFFBFFRLL
FFFBBBBLRL
FBBBFBFRLL
BBFFFBBLRL
FFFBFFBLRR
BBFBFBBRRL
FFFFBBBRRR
FFBBBBBLRL
FFFFFFBLLL
FBFFFFFRRL
FFFFFBBLRR
BFFFBBBRRL
FBBFFFFLRL
FFFFFBBRLR
FFBFFBFRLL
FFFBBBFRRL
BFBBBFFLRL
FFFFFBFLRR
BFBFBBBRLR
FBFBBBFLLL
BFBFFBFLRL
FFBFBFFRRR
FFBBFFFRLL
BFBFBFFLLL
FBFBFBBRLR
BFFBBBFRRL
FBFFBBBRRR
FBFBFBBLRR
BFBBBBFLLR
FFFBFFFRLR
BFBBFFBRRL
BFFFBFFLRL
BFBFBBFRRR
FBBFFBFLLL
FFFFFFBLRR
FBFFBFBLRR
FFBBBFFLRR
FBBBFFBRLL
BFFFBBBRRR
FFBFFFFRLL
BBFFFBFRRR
BFFBFBBLLL
BFBBFFBRLR
FFBFBBBLRR
FFFBFBBLLL
FFFBBFFLLL
FBBBBBBLRL
BFBFBBBLLL
BFBFFFFRRL
FFBFBBFRRR
FFBFBFBRRL
FFFBBBBRLL
BFFBFFBRLL
BBFFFFBRRL
FFBFBFBLLL
FFBFBFBRLL
FBFBBBFRRL
FBFFBBFRLR
BBBFFFFLRL
FBFBFFFRRL
FFFBFBFRLR
FBFBFBBRRL
BFBBFBBLLL
FFBBBBBRLL
BBFFBFBRRL
FFFBFFFRRR
FBBFBFBLLL
BFFFBFFRLR
FBFBFFBRLL
BBFBBFFLLL
FBBBBFFLRR
FFBBBFFLRL
FBBBFFBRRR
FFBBFBBRLR
FBFBBFFLLR
BFBBBFFLLR
FFFBBFFLRR
FBFFBFFLRL
BFBFBFFLRR
BBFBFFFLLR
FFFBBBBLLR
FFBBFFBRLL
BBBFFFBRLL
FBFFBFBRRL
BFBFFFFRLL
FBFBFBFRLR
BBFFFFFLLL
FFBFBBBLLR
FFBFBFFLRR
FBBBBFBRLR
FFBFBBBRLR
BFFBBBBLRL
FFBBBBBRLR
BFBBBFFRRR
FBFBBFBRLL
FFBFFFBRRL
BBFBFBFLLL
BFBBBFBRLR
BFBBFBFLLR
FBBFBFFRLL
FFBFBBFLRR
BFFBFBFRLL
FFBBFBBLRL
FBFBFBBLRL
BBFFFBFLLR
BFBFBBBLRR
BBFFBBBLLR
BBFFFFBRRR
BFFFFFBLRL
FBBBFBBRRR
BFBFFFBLLL
FFFBBFFLLR
BFFBBFFLLR
BBFBBBBLRL
FBBFBFFLRR
FBFBFFBLLR
BFFFFFFLLL
BFFBBFFRLL
BBFFFFFLLR
FBFFBBFRRL
FBBFFFFLLR
BFBFFBBRRL
FFBFFFBLLL
BFFFFFBLLR
FFBBBFBRRL
FFBBBBFLLR
BFBFFFBLLR
FFFFBFFRLR
BFBBFFBRLL
FFBBBBBLLL
FBBFBFFRRR
BFFFFFFLLR
FFBBBBBLRR
FFFFFBFRRR
BFFFBBBLLL
BFFFBFFRRR
FFBBBFBRLR
BFFBBBBLRR
BFBBBFFRRL
BFBFBFFRRR
BFBBFBBRLR
BFBBBBFRLL
FFBBBBFLLL
FFFBBFBLRR
FBBFBBFRLR
BBFBBFFLRR
FBBFBBBRRL
BFFBFFFRRL
BFFFFBFLRR
FFBFBBFLLL
FFBFBBBLLL
FBFFBFBRRR
FFFBFFBRLL
BFFFFBFLRL
FFFFBFFLLR
BBFBBBBRLL
FBFBBFBRRR
BFFFBBBLRR
FBFFFBFRLL
FFBBBFBLRL
FBFFFBBLRR
FFBBFBFRLR
FBBBBBFLRL
FFFFBFBLRR
BFBFBFBLRR
FFBBFFFLRL
BFFBBBFLLR
FFFFFFBRLR
FFBBBFBLRR
FBFBBFFRLL
BBFBFBFRLR
FBBFFFFLLL
BFBBFBFRRR
BFFBBBFRRR
FBFFFBFLRR
FBBFFBFLRL
BFBBFFFLRR
FFBFFFFLRL
BFFBFFBLLL
FFFBFBBRRR
BBFFBFFLRR
BBBFFFFRRL
FBBBFFBLRL
FBBFFBBLRR
FFBFBFFLLR
FFFBBFFRLR
FBBBFBBRLR
FFFFBBBLRR
BBFFBFBRRR
FBFBBFFLRL
FBBBBFFLLL
FFBFFBBRLR
BBFFFFFLRR
FFBFBFBRLR
FFBFBFBLRL
FBBBFBBLRL
FFFBFBBLRL
FBFBFFFRRR
BFFBFFFRLR
BFBBFFBLLR
BFBFFBFRLL
FBFBFBFRRR
FBFFFFBRLL
FFFFFBBRRR
FBBBFFFLRL
FFFBFFBRLR
BFBFFBFLRR
FBBFBBFRRL
BFBBBBFRRR
BFFFFBBLRR
FBFFFFFLLL
BFBFFFBRRL
FFFBFFBLRL
FFBFFFBLRR
FBBFFBFRLL
BBFBFFBLLL
BBFFBBFLLL
FFBBBFFRLL
BFBBFFFLRL
FBBFBFFLLR
FBFBFFBLLL
FFBBBFFLLR
FBBFFBFLRR
FBBFBBFRRR
BFFFFBBLLL
FFFBFFBLLR
FBFBFFFRLR
FBFBFBBRRR
FBFBBFBRRL
BBFBBFBRRR
FFFFBBBRLL
FBFFBBBLRL
BBBFFFFRLL
FBFFFBFLRL
BFFFFBFLLR
FBFBBFFRRL
BFFBFBBLRR
FBFBBBBRRL
FBFBFBBLLR
FBFFBBFLRR
FFFFBFFLLL
BFBFFFFRRR
BBFFBBBLRR
FBFFFFFLLR
BBFBFFFRLR
BFFFFBBRLR
FBFFFFFLRL
FBBBFBBLRR
BFFBBFBLLL
BFFBFBBLRL
BFFBBBFRLL
FFBFFBFRRR
BFBFBFBRLL
BBFBBFBLLR
FBFBBFBLRL
FBFFFBBRLR
BBFBFFBRLL
BBFFFBFRLR
FBBFFFBLLL
BBFBBBBLLL
BFFFFFFLRR
FBBBBBFRLL
BFFFBFBRRR
BFFFFFFLRL
FBBBBFBLRR
FBFFBBBRLR
FFBBFBFRRL
FFBBFBBRRL
FFFBFBFRRR
FFBBBBFLRL
BFBBFFFRRR
FBFBBBBRLL
FBFFBBFRLL
FFBFFFFRRR
BFFFFBBLLR
FBFBBFBLLR
BBFFBBBRRR
FBBFBBBRLR
BFBFBFFRLL
BFFBBFBLRL
BFFBFFFRRR
FFBBBFBRLL
FBFFBFFRRL
FBBBBFFRRR
FFFBBBFRLL
BBFFFBBRLL
BBFFFBBRLR
FFBBFFFRRL
BBFFBFBLRR
BBFBFFBRRR
BFBBBBBLRR
BFFBBFFLRL
BBFFFFBLLL
FFFFBFBRRL
FBBFFBBRRR
FBBBFFFLRR
FBBFBBFLRR
FBBBFBBLLL
FFFFBBFLRL
FFFFFBBLLL
BFBBBBBLLR
BFBFFFFLRR
FBFFFFBLLR
BBFFBBBRLL
FBFFBFFRRR
FFBBFBFLLR
BBFBBBFLRR
FBBBBBBRLL
FFFFFFBLLR
FFFFFBFRLR
FBFFBFBRLL
BBFFBFFRRR
BFFBFFFLLR
FFBBFBBLRR
BBFFBBBRLR
FFBBFFBRRL
FBBBBFFRRL
BFBFFFFRLR
BFBBBFBLLL
BFBFFFBRRR
FBBBFFFRLR
BFBBFFBLRR
BBFBBFFRLR
BBFFFBBRRR
FFFFBBBRRL
FFBFBBFRLL
FBFFFFBRRL
FBBBFFBRLR
FFBFFFBRRR
FBBBBBBLLL
BFFBFFBLRL
FBFFBBBRLL
BBFBBBFRLR
BFBFBFBRLR
BBFFFFBRLL
FFBBFBBLLR
FFBBFFBRLR
BBFBBBBRLR
BFBBBFBLLR
FFFFBFFRRR
BBFFFBFRRL
FBBFBBBLLL
FFFBFFFLRL
BFFFFBBRRR
FFFBFBFLRL
BBFFBBFRRR
FBBFFFFLRR
FFFBBBFLRL
BFFBBBFLLL
BFBBFFBLLL
FFFFFFBLRL
FBFFBFFLLL
FBBBBBBRRR
FBBFFBBRLR
BFFFBBBLLR
BBFBBBBRRR
BFBFBFFLLR
BFBFFBFRLR
FBBBFFFRRR
FFBFBBFRLR
FFFFFBFRLL
FFBFBBBRRR
BFBFFBBLLL
FBBBBBFRLR
FFBBFBBLLL
BFBFFBBLRL
FBBFBFBRRL
BFFBBBBRRL
FBBFFFBLRL
FBBFBFBLLR
FBBFBBBLRR
BFBBBFBRRL
FBBBFBFLLL
BFFFBFFLLR
FBBBFBFLRR
FFBFFBBLRL
BBFBBBBLLR
BFFFBFFLLL
FBFFFFFLRR
BBFBFBBLRL
BFBFBBFRRL
FBFBFFBLRR
BFFFFFFRRL
BFFFFBFRLR
BFBBFBBRLL
BBFFFFFRLL
FFBBFFFLLR
FFFBFFFLRR
FFFBFFBRRR
BBFBFFBLLR
BFFBFFFRLL
FBFBFFBRRL
BFBBBFFLLL
BBFFBFBLRL
FBFBBFFLRR
FBBFBBBRRR
FFFBBFBRLL
FBBFBFBRRR
BFFFBBFLLL
FBBBFFBLRR
BFBFFBBRRR
FFFFFFBRLL
BBFFFBFLRL
BFBFBFBRRR
BFFFBBFRLR
BFBFFFBLRR
FFFBFFBRRL
BBFFFBBRRL
BFBBBFBRLL
BFBFFFBLRL
FFFBFFFLLR
BFFBFFFLRL
BBFBBFBLRR
FBBBFBBRRL
FBBFBFFRLR
FBFFFFFRLR
FBBBBFFRLR
BFBFBBFRLL
BBFBFBFRRR
BFBFBFBRRL
FBBBBBBRLR
BFBFBBFLLR
BFFFBBFRRL
BBBFFFFRLR
BBBFFFBLLR
FBFBBBFLRR
FBFFFBBLRL
FBFFBBBLLR
BFBFBBFLRR
BFBBFBBLRL
BFFFFFBRRL
FFBBFFFRLR
BFFBBFFRLR
BFBFBFBLRL
BFFBFBFRLR
FFBBFFBRRR
BFBBBBBLLL
BBFFFFFRRL
BBFFFFFLRL
FFFBBFFLRL
BFBBFBFRLL
FFFBBBBLLL
FFFFFBFLRL
FFFFBBFLRR
FBFFFBFRRR
BFFBBBBLLL
BBFBBFFRRL
BFFFBBFLLR
FBBBFFFLLL
FFBFFBBRRL
BFBBBFBLRR
BFFBBBFLRL
BFBBBBBRLL
FFFBBBFRLR
FFFFBFFRRL
FFBFBFFLLL
BBFBFFFLRL
BFFFBBFLRR
FFFBFBFRLL
BFBFFBBLRR
FFFBFBBLLR
BBFFFFFRLR
FFBFBFFRRL
FFFFFBBLRL
FBBBFBFRRL
FBBBBFBLLL
FFFFBBBRLR
FBBBBFFLRL
BFBBBBBRRL
BBFFBFBLLR
FBFBFFFLRL
FBFFFBFRRL
FFFBBFBLRL
BFFFFFBLLL
BFFBFBFLLL
FFFFBBFRRL
FFFBFBBRLR
FBFBBBBRRR
FBFFBBBLLL
FFBBBBFRRR
BFFFFBFRLL
BBFBFBBRLR
BFFBBBFLRR
FBBFBFFRRL
FFFFFBFLLL
BBFBFBFLRR
FFBFBBFLRL
BFFBBFBRLR
FFBBBFFRLR
FFFBBFBRLR
FBFBBBBLLR
BFFBBBBLLR
BBFBFBFLRL
BBFFFFFRRR
FFFBFFFRRL
FBBFFBFRRR
BBFFBFFRLL
FFBBFBFRLL
FFFFBFBLLR
BBFFBBFRLL
BFBBBBFLRL
FBFFBFFRLR
BFBFBBFLLL
FFFFBBFLLL
BFBBBBBLRL
FFBFBFBLRR
BFFFFFBRRR
FBFBBBBLRL
FBBFBBFLLR
FBBFFFFRRL
FBFFFBFLLL
FBFFBBBRRL
FFBFFFFRLR
FBBFBBBRLL
FFFFBFBRLR
FFBFBBBRRL
BFFBFBFRRL
FFBFFBFLLL
BFFBFBFLRR
BBFBFFBLRL
BBFFBFFLLR
BFBBBBFLLL
BBFBBFFRRR
BBFFFBBLRR
BFBFFBFRRL
FBBFBFBLRR
BBFBBBFRRR
FFFBBFBLLR
FFFBFFFLLL
FBBBFBFLLR
BFBBFBFLLL
BFBFBFBLLL
BBFFBBFLRR
FFFBFBFLRR
BFFFFFFRLR
BBFBFBBRRR
BBFFFBFRLL
FFFFBBFRLL
FBBFBBFRLL
FBFFFFBRRR
FBFFBBFLLR
BFFBFFBLLR
FFBFFBFLRR
FBFFBFBRLR
FBFBBFFLLL
FBBFFFBRRL
FBFBFBFRRL
FFBFBFBRRR
FBFBFBFLRL
FFFBFBBRLL
FBBBFFFLLR
FFBBBBFRLL
FBFFFBBRLL
BFFBFFBLRR
FBBFBBFLRL
FBFFFBBRRR
FBFFFBBLLR
BFFBFFBRRR
FBBBFBFRRR
FBFFFFFRLL
BBFBBBFRLL
FFFBFFBLLL
FFBFFFFLRR
FBFFFBBRRL
BBFFBFFRLR
FBFBFBBLLL
FBBBBBBLLR
FBFBBFBLLL
BBFBFFFLRR
BFFFFBBRRL
BBFFFBFLRR
FFBFFFBRLL
FFFFBBBLRL
BFBBBFFRLL
BBFBFFFRLL
FBFBBBBLLL
BBFBBFBRLR
BBFFBFBRLR
BFBFFFFLRL
FBBBFBFRLR
FFBFFFBRLR
FBBBBBFLLR
FFBBBFBLLR
BFFBBFBRRL
BBFFBFFRRL
FFFFFFBRRR
FFBBFBBRRR
FBBBBBBRRL
BFFBBFFRRL
FBBFBFBRLR
FBBFFFFRLL
FBBBBBFLLL
FBBFFFBRRR
BFFFFBBLRL
FFFFBFBLLL
FBFBFFFLLL
FBFBBFBLRR
FFFFBFFLRR
FFFBBBFLRR
FBFFBFFLLR
BBFFBFFLLL
FFBFFBFRRL
BFBBFBBRRR
BBFFFBFLLL
FBFFBFBLLL
BFFBFFBRRL
BBFBFFBLRR
FBFBFFFLRR
BFBBFBBLLR
BFFBBFFRRR
FFFFFFBRRL
BBBFFFFLLR
BFBFFBFLLL
FBBBBBFRRL
BFFBBBBRLR
FFBBFBFLRL
FBFBFFBLRL
FFBBBBFRLR
BBFBBFBRRL
FFFFFBFLLR
FBFBFBFLLL
BFBFBFBLLR
FFFBFFFRLL
BFFBBFBLLR
FFBBFBBRLL
FFFBBFBRRL
FBBFFBBLLL
FFFBBBBRLR
FFFBBFBRRR
BBFFBBBRRL
FBBFBFFLRL
FBBBBBFLRR
BBFBFFBRRL
FFFBFBFLLL
FBBBFFFRLL
BFFBFBFLLR
FFBBBBBRRL
BFFBBFFLRR
FBBFBFBRLL
BFFFBFFRRL
BBFFFFBLLR
BBFFBBFRLR
BFFFBBFRRR
FBFBBFBRLR
FFFFFBBRLL
FBBFFFBRLL
BFFFFFBRLL
BFFFBFBLRR
BFFBFFBRLR
FFFFBFBLRL
FFBFFBFLLR
FBBFBFFLLL
BFFBFBFRRR
BBFBBBFLRL
BBBFFFFLRR
BFBBFFFLLR
FBBFFFBRLR
FFFFFBFRRL
FFFBFBBRRL
BBBFFFBLRR
FFBFBBFRRL
FFBBFFBLRR
BBFFBBBLLL
BFBFBBBRRL
BFFFBFBRLL
FFBFBBBRLL
FBFBFBFLRR
FBFFFBBLLL
FBBFFBFLLR
BFFFFBFRRL
FFBBBFFRRL
FFBFBFFLRL
BBFBBBFLLR
FBBFFBFRLR
FBBFFBBRLL
BFBFFFBRLR
BFFFBFFRLL
BBFBFBBRLL
BFFFFFFRLL
FBFBBBFRLL
BFBBFBFLRR
BFBFBBBRLL
BBFBBBFRRL
BFFBBFBRRR
BFBFFBFLLR
FBFBFBFLLR
FFFFFBBRRL
FBFBBBFRLR
FBFFBBFLLL
FFBFBFFRLR
BBFBFBBLLL
FFFFBFFLRL
FBBFBBFLLL
BFBFBBFLRL
FFFFBBFLLR
BFBBFBBRRL
FBBBFFBRRL
FBBBBFFRLL";
    }
}
