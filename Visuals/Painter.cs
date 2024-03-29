﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gpl.Compiler.Syntax;
using gpl.Compiler;

namespace gpl.Visuals
{
    /// <summary>
    /// Class that directs specific syntax statements to their function implementation.
    /// </summary>
    public class Painter
    {
        private StatementSyntax _statement;
        private Canvas _canvas;

        /// <summary>
        /// Constructor to pass required parameters.
        /// </summary>
        /// <param name="canvas">Object of canvas</param>
        /// <param name="statement">Object of StatementSyntax class</param>
        public Painter(Canvas canvas, StatementSyntax statement)
        {
            _canvas = canvas;
            _statement = statement;
        }

        /// <summary>
        /// Paint method that guides which function to call depending upon the type of 
        /// Syntax statement
        /// </summary>
        public void Paint()
        {
            switch (_statement.Kind)
            {
                case SyntaxKind.MoveToStatement:
                    var moveto = (MoveToStatementSyntax)_statement;
                    _canvas.MoveTo(moveto.Point[0], moveto.Point[1]);
                    break;

                case SyntaxKind.DrawToStatement:
                    var drawto = (DrawToStatementSyntax)_statement;
                    _canvas.DrawTo(drawto.Point[0], drawto.Point[1]);
                    break;

                case SyntaxKind.PenStatement:
                    var pen = (PenStatementSyntax)_statement;
                    _canvas.SetPen(pen.Color);
                    break;

                case SyntaxKind.BrushStatement:
                    var brush = (BrushStatementSyntax)_statement;
                    _canvas.SetBrush(brush.Color);
                    break;

                case SyntaxKind.FillStatement:
                    var fill = (FillStatementSyntax)_statement;
                    _canvas.SetFillState(fill.State);
                    break;

                case SyntaxKind.RectangleStatement:
                    var rectangle = (RectangleStatementSyntax)_statement;
                    _canvas.Draw(rectangle);
                    break;

                case SyntaxKind.CircleStatement:
                    var circle = (CircleStatementSyntax)_statement;
                    _canvas.Draw(circle);
                    break;

                case SyntaxKind.TriangleStatement:
                    var triangle = (TriangleStatementSyntax)_statement;
                    _canvas.Draw(triangle);
                    break;
            }
        }
    }
}
