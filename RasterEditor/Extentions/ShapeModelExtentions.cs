// <copyright file="ShapeModelExtentions.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.R42Extentions
{
    using System.Collections.Generic;
    using System.Linq;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;

    /// <summary>
    /// Extention class
    /// </summary>
    public static partial class ExtentionsClass
    {
        /// <summary>
        /// Returns the first index
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>1 based index</returns>
        public static int FirstColumn(this ShapeModel shapeModel)
        {
            return shapeModel.Blocks.Min(b => b.Column);
        }

        /// <summary>
        /// Returns the last index
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>1 based index</returns>
        public static int LastColumn(this ShapeModel shapeModel)
        {
            return shapeModel.Blocks.Max(b => b.Column);
        }

        /// <summary>
        /// Gets the row index.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>1 based index</returns>
        public static int FirstRow(this ShapeModel shapeModel)
        {
            return shapeModel.Blocks.Min(b => b.Row);
        }

        /// <summary>
        /// Returns the last row index.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>1 based index</returns>
        public static int LastRow(this ShapeModel shapeModel)
        {
            return shapeModel.Blocks.Max(b => b.Row);
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="row">The row.</param>
        /// <returns>Specified row</returns>
        public static IEnumerable<BlockModel> GetRow(this ShapeModel shapeModel, int row)
        {
            return shapeModel.Blocks.Where(b => b.Row == row);
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        /// <returns>Specified column</returns>
        public static IEnumerable<BlockModel> GetColumn(this ShapeModel shapeModel, int column)
        {
            return shapeModel.Blocks.Where(b => b.Column == column);
        }

        /// <summary>
        /// Adds the row to the top
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void AddRowTop(this ShapeModel shapeModel)
        {
            var maxColumns = shapeModel.LastColumn();
            shapeModel.Blocks.ForEach(b => b.Row = b.Row + 1);
            for (var col = 0; col < maxColumns; col++)
            {
                var newBlock = BlockModel.Create(col + 1, 1);
                shapeModel.Blocks.Add(newBlock);
            }
        }

        /// <summary>
        /// Adds the row at the bottom
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void AddRowBottom(this ShapeModel shapeModel)
        {
            var maxRow = shapeModel.LastRow();
            var maxColumns = shapeModel.LastColumn();

            var newRow = maxRow + 1;

            for (var col = 0; col < maxColumns; col++)
            {
                var newBlock = BlockModel.Create(col + 1, newRow);
                shapeModel.Blocks.Add(newBlock);
            }
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void AddColumnLeft(this ShapeModel shapeModel)
        {
            var maxRow = shapeModel.LastRow();
            shapeModel.Blocks.ForEach(b => b.Column = b.Column + 1);

            for (var row = 0; row < maxRow; row++)
            {
                var newBlock = BlockModel.Create(1, row + 1);
                shapeModel.Blocks.Add(newBlock);
            }
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void AddColumnRight(this ShapeModel shapeModel)
        {
            var maxRow = shapeModel.LastRow();
            var maxColumns = shapeModel.LastColumn();

            var newColumn = maxColumns + 1;

            for (var row = 0; row < maxRow; row++)
            {
                var newBlock = BlockModel.Create(newColumn, row + 1);
                shapeModel.Blocks.Add(newBlock);
            }
        }

        /// <summary>
        /// Removes the last column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void RemoveColumnLeft(this ShapeModel shapeModel)
        {
            shapeModel.RemoveColumn(shapeModel.FirstColumn());
        }

        /// <summary>
        /// Removes the last column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void RemoveColumnRight(this ShapeModel shapeModel)
        {
            shapeModel.RemoveColumn(shapeModel.LastColumn());
        }

        /// <summary>
        /// Removes the first row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void RemoveRowTop(this ShapeModel shapeModel)
        {
            shapeModel.RemoveRow(shapeModel.FirstRow());
        }

        /// <summary>
        /// Removes the last row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void RemoveRowBottom(this ShapeModel shapeModel)
        {
            shapeModel.RemoveRow(shapeModel.LastRow());
        }

        /// <summary>
        /// Gets the block.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <returns>Returns a BlockModel</returns>
        public static BlockModel GetBlock(this ShapeModel shapeModel, int column, int row)
        {
            return shapeModel.Blocks.Single(b => b.Column == column && b.Row == row);
        }

        /// <summary>
        /// Moves up.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void MoveUp(this ShapeModel shapeModel)
        {
            shapeModel.AddRowBottom();
            shapeModel.RemoveRowTop();
        }

        /// <summary>
        /// Moves down.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void MoveDown(this ShapeModel shapeModel)
        {
            shapeModel.AddRowTop();
            shapeModel.RemoveRowBottom();
        }

        /// <summary>
        /// Moves the right.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void MoveRight(this ShapeModel shapeModel)
        {
            shapeModel.RemoveColumnRight();
            shapeModel.AddColumnLeft();
        }

        /// <summary>
        /// Moves the left.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void MoveLeft(this ShapeModel shapeModel)
        {
            shapeModel.RemoveColumnLeft();
            shapeModel.AddColumnRight();
        }

        /// <summary>
        /// Removes the row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="row">The row.</param>
        public static void RemoveRow(this ShapeModel shapeModel, int row)
        {
            shapeModel.Blocks.RemoveAll(b => b.Row == row);
            shapeModel.Blocks.Where(b => b.Row > row).ToList().ForEach(b => b.Row = b.Row - 1);
        }

        /// <summary>
        /// Removes the column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        public static void RemoveColumn(this ShapeModel shapeModel, int column)
        {
            shapeModel.Blocks.RemoveAll(b => b.Column == column);
            shapeModel.Blocks.Where(b => b.Column > column).ToList().ForEach(b => b.Column = b.Column - 1);
        }

        /// <summary>
        /// Crops the image.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void CropImage(this ShapeModel shapeModel)
        {
            var rowsToRemove = shapeModel.GetRowsToRemove();
            var columnsToRemove = shapeModel.GetColumnsToRemove();

            foreach (var row in rowsToRemove)
            {
                shapeModel.RemoveRow(row);
            }

            foreach (var column in columnsToRemove)
            {
                shapeModel.RemoveColumn(column);
            }
        }

        /// <summary>
        /// Sets the BlockModel's Anrchor contained by the ShapeModel to false.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void ResetAnchor(this ShapeModel shapeModel)
        {
            shapeModel.Blocks.ForEach(b => b.Anchor = false);
        }

        /// <summary>
        /// Sets the anchor.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        public static void SetAnchor(this ShapeModel shapeModel, int column, int row)
        {
            shapeModel.GetBlock(column, row).Anchor = true;
        }

        /// <summary>
        /// Gets the anchor block.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>Block Model</returns>
        public static BlockModel GetAnchorBlock(this ShapeModel shapeModel)
        {
            return shapeModel.Blocks.SingleOrDefault(b => b.Anchor == true);
        }

        /// <summary>
        /// Gets the columns to remove.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>A list of column indexes</returns>
        private static List<int> GetColumnsToRemove(this ShapeModel shapeModel)
        {
            var columnsToRemove = new List<int>();
            for (int col = shapeModel.LastColumn(); col >= 1; col--)
            {
                if (shapeModel.GetColumn(col).All(b => b.Color == CGA16Colors.Black.GetColor()))
                {
                    columnsToRemove.Add(col);
                }
                else
                {
                    break;
                }
            }

            for (int col = 1; col <= shapeModel.LastColumn(); col++)
            {
                if (shapeModel.GetColumn(col).All(b => b.Color == CGA16Colors.Black.GetColor()))
                {
                    columnsToRemove.Add(col);
                }
                else
                {
                    break;
                }
            }

            columnsToRemove.Sort();
            columnsToRemove.Reverse();

            return columnsToRemove;
        }

        /// <summary>
        /// Gets the rows to remove.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>A list of row indexes</returns>
        private static List<int> GetRowsToRemove(this ShapeModel shapeModel)
        {
            var rowsToRemove = new List<int>();
            for (int row = shapeModel.LastRow(); row >= 1; row--)
            {
                if (shapeModel.GetRow(row).All(b => b.Color == CGA16Colors.Black.GetColor()))
                {
                    rowsToRemove.Add(row);
                }
                else
                {
                    break;
                }
            }

            for (int row = 1; row <= shapeModel.LastRow(); row++)
            {
                if (shapeModel.GetRow(row).All(b => b.Color == CGA16Colors.Black.GetColor()))
                {
                    rowsToRemove.Add(row);
                }
                else
                {
                    break;
                }
            }

            rowsToRemove.Sort();
            rowsToRemove.Reverse();
            return rowsToRemove;
        }
    }
}
