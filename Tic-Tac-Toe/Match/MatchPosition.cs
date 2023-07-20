using gameBoard;
using System.Text;

namespace match {
    internal class MatchPosition {
        public int Row { get; set; }
        public char Column { get; set; }

        public MatchPosition(int row, char column) {
            Row = row;
            Column = column;
        }

        public Position ToPosition() {
            return new Position(Row - 1, Column - 'a');
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.Append(Column);
            sb.Append(Row);

            return sb.ToString();
        }
    }
}
