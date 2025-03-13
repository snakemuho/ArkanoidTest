# Arkanoid

A prototype of a simple arkanoid game, where you have to bounce the ball and break all the bricks to win.

---

## 🎮 **Gameplay Overview**

In this game:
- The platform is controlled with left and right screen buttons.
- The bricks can drop extra balls and an upgrade for the platform's size.
- If all the balls fall, the game is over.

![Game Preview](https://github.com/user-attachments/assets/6b7f527f-d32e-4689-8c38-4e59a6f3bde9)

---

## 🔧 **Features**

### 1. **Dynamic Bricks Generation**
- Levels are generated dynamically, defined by `LevelSettings` ScriptableObjects located in `Assets/Settings`
- This ScriptableObject stores the brick types to spawn and their spawn chance, the number of generated rows and columns, spacing between the bricks, start Y position and possible random brick colors.

![Settings](https://github.com/user-attachments/assets/7c28c9aa-bef3-4996-a2cf-25e434d8089d)

### 2. **Bricks**
- New brick types can be created by inheriting from the `Brick` abstract class.

### 3. **Powerups**
- Like with bricks, new powerup types can be created by inheriting from the `Powerup` abstract class.

---


