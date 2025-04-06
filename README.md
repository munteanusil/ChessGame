# ChessGame WPF
A desktop chess game developed in C# using WPF and object-oriented design. The project simulates a real chess match, including all standard rules, move generation, and piece behavior.

## 🛠️ Technologies & Concepts Used

- **C# (.NET 6)** – Core programming language used to build game logic
- **WPF (Windows Presentation Foundation)** – For building the UI and rendering the chessboard
- **Object-Oriented Programming (OOP)** – Each piece (`Pawn`, `Knight`, etc.) is represented as a separate class inheriting from an abstract `Piece`
- **Enums & Indexers** – For clean and readable access to positions and pieces on the board
- **Move Generation Algorithms**:
  - Sliding movement (for `Rook`, `Bishop`, `Queen`) using direction vectors
  - L-shaped movement for `Knight`
  - Special rules: `Castling`, `En Passant`, `Promotion`
- **Custom Chess Engine Logic** – Tracks the board state and validates moves based on game rules
- **Yield-based Iterators (`yield return`)** – Efficient on-the-fly move generation
- **Board Class with Indexers** – Accesses pieces directly by row/column or position
- **IEnumerable<Move>** – Used for flexibility and LINQ integration when generating moves

## ♟ Features

- All standard chess piece movement logic
- Castling (both kingside and queenside)
- En passant and pawn promotion
- Real-time visual board rendering with image assets
- Support for switching turns between White and Black
- Move validation and basic game state tracking
