using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Doodle_jump
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public struct rect
        {
            public Texture2D texture;
            public Rectangle posize;
            public void draw(SpriteBatch s)
            {
                s.Draw(texture, posize, Color.White);
            }

            public bool Collision(doodle s)
            {
                if ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60))

                    if (posize.Y - s.posize.Y - 60 < 5 && posize.Y - s.posize.Y - 60 > -20 && s.speed.Y > 0)
                        return true;
                    else return false;
                else return false;
            }
        }

        public struct fakeRect
        {
            public Texture2D texture;
            public Rectangle posize;
            public void draw(SpriteBatch s)
            {
                s.Draw(texture, posize, Color.White);
            }

            public bool Collision(doodle s)
            {
                if ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60))

                    if (posize.Y - s.posize.Y - 60 < 5 && posize.Y - s.posize.Y - 60 > -20 && s.speed.Y > 0)
                        return true;
                    else return false;
                else return false;
            }
        }

        public struct goneRect
        {
            public Texture2D texture;
            public Rectangle posize;
            public void draw(SpriteBatch s)
            {
                s.Draw(texture, posize, Color.White);
            }

            public bool Collision(doodle s)
            {
                if ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60))

                    if (posize.Y - s.posize.Y - 60 < 5 && posize.Y - s.posize.Y - 60 > -20 && s.speed.Y > 0)
                        return true;
                    else return false;
                else return false;
            }
        }

        public struct movingRect
        {
            public Texture2D texture;
            public Rectangle posize;
            public int speed;
            public void draw(SpriteBatch s)
            {
                s.Draw(texture, posize, Color.White);
            }

            public void move()
            {
                posize.X += speed;
                if (posize.X > 420 || posize.X < 0) speed *= -1;
            }

            public bool Collision(doodle s)
            {
                if ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60))

                    if (posize.Y - s.posize.Y - 60 < 5 && posize.Y - s.posize.Y - 60 > -20 && s.speed.Y > 0)
                        return true;
                    else return false;
                else return false;
            }
        }

        public struct doodle
        {
            public Texture2D textureR;
            public Texture2D textureL;
            public Texture2D textureC;
            public Texture2D nose;
            public Texture2D test;
            public Rectangle posize;
            public Vector2 speed;
            public const int accelarator=+1;
            public int ch;
            public float degree;
            

            public void move()
            {
                if (ch == 0)
                {
                    speed.Y += accelarator;
                    ch = 1;
                }
                else
                    ch = 0;

                posize.Y += (int)speed.Y;
            }

            public void draw(SpriteBatch s, ref cond name, MouseState m, int game)
            {
                if (game == gameRunning)
                switch(name)
                {
                    case cond.Left: s.Draw(textureL, posize, Color.White);break;
                    case cond.Right: s.Draw(textureR, posize, Color.White); break;
                    case cond.Tir: s.Draw(textureC, posize, Color.White);
                        s.Draw(nose, posize, Color.White);
                         //s.Draw(nose, new Rectangle(posize.X+14,posize.Y+13,60,60), null, Color.White,-MathHelper.PiOver2, new Vector2(30,27), SpriteEffects.None, 0f);
                         //s.Draw(test, new Vector2(posize.X+28,posize.Y+ 27), Color.White);
                         name = cond.Left;
                        break;

                }   
            }
        }

        public struct movablenemy
        {
            public Texture2D EnemyR;
            public Texture2D EnemyL;
            public Vector2 speed;
            public Rectangle posize;

            public void draw(SpriteBatch s)
            {
                if(speed.X>0)
                    s.Draw(EnemyR, posize, Color.White);
                else
                    s.Draw(EnemyL, posize, Color.White);
            }
            public void move()
            {
                posize.X += (int)speed.X;
                if (posize.X > 410)
                    speed.X *= -1;
                if (posize.X < 10)
                    speed.X *= -1;
            }
            public int Collision(doodle s, bool collisionCheck)
            {
                if (posize.Y - s.posize.Y - 45 < 5 && posize.Y - s.posize.Y - 45 > -15 && s.speed.Y > 0 && ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60)))
                {
                    return (0);// our enemy is dead!
                }
                else if (posize.Y - s.posize.Y < 5 && posize.Y - s.posize.Y > -35 && s.speed.Y < 0 && ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60)))
                {
                    collisionCheck = false;
                    return (1);// you are dead!

                }
                else
                {
                    collisionCheck = true;
                    return (2);
                }

            }
            public bool tirCollision(tir s)
            {
                if (s.posize.X > posize.X && s.posize.X + s.posize.Width < posize.X + posize.Width && s.posize.Y > posize.Y && s.posize.Y + s.posize.Height < posize.Y + posize.Height) return true;
                else return false;
            }
        }

        public struct staticEnemy
        {
            public Texture2D enemy;
            public Vector2 speed;
            public Rectangle posize;

            public void draw(SpriteBatch s)
            {
                s.Draw(enemy, posize, Color.White);
            }
            public int Collision(doodle s, bool collisionCheck)
            {
                if (posize.Y - s.posize.Y - 45 < 5 && posize.Y - s.posize.Y - 45 > -15 && s.speed.Y > 0 && ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60)))
                {
                    return (0);// our enemy is dead!
                }
                else if (posize.Y - s.posize.Y < 5 && posize.Y - s.posize.Y > -35 && s.speed.Y < 0 && ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60)))
                {
                    collisionCheck = false;
                    return (1);// you are dead!

                }
                else
                {
                    collisionCheck = true;
                    return (2);
                }

            }
            public bool tirCollision(tir s)
            {
               // if (posize.Y - s.posize.Y - 45 < 5 && posize.Y - s.posize.Y - 45 > -15  && ((s.posize.X > posize.X && s.posize.X < posize.X + 20) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 20))) return true;
                //else return false;
                if(s.posize.X>posize.X && s.posize.X+s.posize.Width<posize.X+posize.Width && s.posize.Y>posize.Y && s.posize.Y+s.posize.Height<posize.Y+posize.Height)return true;
                else return false;
            }
        }

        public struct bigEnemy
        {
            public Texture2D enemy;
            public Vector2 speed;
            public Rectangle posize;

            public void draw(SpriteBatch s)
            {
                s.Draw(enemy, posize, Color.White);
            }
            public int Collision(doodle s)
            {
                if (posize.Y - s.posize.Y - 30 < 5 && posize.Y - s.posize.Y - 30 > -15 && s.speed.Y > 0)
                    if ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60))
                        return (0);// your enemy is dead!
                    else if (posize.Y - s.posize.Y < 5 && posize.Y - s.posize.Y > -15 && s.speed.Y < 0)
                        if ((s.posize.X + 15 > posize.X && s.posize.X + 15 < posize.X + 60) || (s.posize.X + 45 > posize.X && s.posize.X + 45 < posize.X + 60))
                            return (1);// you are dead!
                        else return (2);
                    else return (2);
                else return (2);
            

            }
        }

        public struct tir
        {
            public Texture2D texture;
            public Rectangle posize;
            public Vector2 speed;
            public const float accelertion = 0.5f;
            public void draw(SpriteBatch s, int game)
            {
                if (game == 1)
                    s.Draw(texture, posize, Color.White);
            }
            public void move(doodle s)
            {
                speed.Y += accelertion;
                posize.Y += (int)speed.Y;
                posize.X += (int)speed.X;
            }
        }

        public struct fanar
        {
            public Texture2D fanarC;
            public Texture2D fanarO;
            public Rectangle posize;

            public void draw(SpriteBatch s,bool check)
            {
                if(!check)
                    s.Draw(fanarC, posize, Color.White);
                else
                    s.Draw(fanarO, posize, Color.White);
            }

            public bool Collision(doodle s, bool collisionCheck)
            {
                if ((s.posize.X + 10 > posize.X && s.posize.X + 10 < posize.X + 60) || (s.posize.X + 50 > posize.X && s.posize.X + 50 < posize.X + 60))
                    if (posize.Y + 17 - s.posize.Y - 60 < 5 && posize.Y + 17 - s.posize.Y - 60 > -15 && s.speed.Y > 0)
                    {
                        if (collisionCheck == true)
                            return true;
                        else
                            return false;
                    }
                    else return false;
                else return false;
            }
        }

        public struct trampo
        {
            public Texture2D texture;
            public Rectangle posize;

            public void draw(SpriteBatch s)
            {
                s.Draw(texture, posize, Color.White);
            }

            public bool Collision(doodle s, bool collisionCheck)
            {
                if ((s.posize.X + 10 > posize.X && s.posize.X + 10 < posize.X + 60) || (s.posize.X + 50 > posize.X && s.posize.X + 50 < posize.X + 60))
                    if (posize.Y + 17 - s.posize.Y - 60 < 5 && posize.Y + 17 - s.posize.Y - 60 > -15 && s.speed.Y > 0)
                    {
                        if (collisionCheck == true)
                            return true;
                        else
                            return false;
                    }
                    else return false;
                else return false;
            }
        }

        public struct background
        {
            public Texture2D back;
            public Texture2D kooh;
            public Texture2D sides;
            public Texture2D introMenu;
            public Texture2D option;
            public Texture2D notif;
            public Texture2D pause;
            public Texture2D sOn;
            public Texture2D sOff;
            public Texture2D gameOvre;
            public Texture2D hScore;
            public Rectangle bPosize;
            public Rectangle kPosize;
            public Rectangle sPosise1;
            public Rectangle sPosise2;
            public Rectangle introMenuposize;
            public Rectangle hScoreposize;
            public Rectangle optionposize;
            public Rectangle notifposize;
            public Rectangle pauseposize;
            public Rectangle gameOverposize;
            public Rectangle sOnposize;
            public Rectangle sOffposize;
            public int hScore1;
            public int hScore2;
            public int hScore3;
            public int hScore4;
            public int hScore5;
            public bool soundCheck;
            public bool gameStateCheck;
           
            public void draw(SpriteBatch s,int game,scor score)
            {
                s.Draw(back, bPosize, Color.White);
                s.Draw(kooh, kPosize, Color.White);
                s.Draw(sides, sPosise1, Color.White);
                s.Draw(sides, sPosise2, Color.White); 
                if (game == 0)
                    s.Draw(introMenu, introMenuposize, Color.White);
                if (game == 2)
                    s.Draw(pause, pauseposize, Color.White);
                if (game == 3)
                {
                    s.Draw(option, optionposize, Color.White);
                    if (soundCheck == true)
                        s.Draw(sOn, sOnposize, Color.White);
                    else
                        s.Draw(sOff, sOffposize, Color.White);
                }
                if (game == 4)
                {
                    s.Draw(gameOvre, gameOverposize, Color.White);
                    s.DrawString(score.spFont, score.s.ToString(), new Vector2(308f,245f), Color.Black);
                    s.DrawString(score.spFont, score.bestS, new Vector2(295f, 297f), Color.Black);
                }
                if (game == 5)
                {
                    s.Draw(hScore, hScoreposize, Color.White);
                    s.DrawString(score.spFont, hScore1.ToString(), new Vector2(215f, 245f), Color.Black);
                    s.DrawString(score.spFont, hScore2.ToString(), new Vector2(215f, 290f), Color.Black);
                    s.DrawString(score.spFont, hScore3.ToString(), new Vector2(215f, 335f), Color.Black);
                    s.DrawString(score.spFont, hScore4.ToString(), new Vector2(215f, 380f), Color.Black);
                    s.DrawString(score.spFont, hScore5.ToString(), new Vector2(215f, 420f), Color.Black);
                }
            }
            public void notifdraw(SpriteBatch s, int game)
            {
                if(game!=0 && game!=3 && game!=5)
                s.Draw(notif, notifposize, Color.White);
            }

            public void sideCheck()
            {
                if (sPosise1.Y > 720)
                    sPosise1.Y = sPosise2.Y-3600;
                if (sPosise2.Y > 720)
                    sPosise2.Y = sPosise1.Y-3600;
            }
        }

        public struct sound
        {
            public SoundEffect back;
            public Song Back;
            public Song rect;
            public bool check;
            public bool playCheck;
        }

        public void playAgain(ref doodle Doodle, ref scor score, ref List<rect> rects, ref fakeRect[] fr, ref goneRect[] gr, ref movingRect[] mr,ref fanar Fanar,ref trampo Trampo,ref tir Tir,ref background Backgraound, ref int gameState)
        {

            gameState = gameRunning;
            MediaPlayer.Play(Sound.Back);
            rect[] r = rects.ToArray();
            collisionCheck = true;
            score.check = true;
            gameover = false;
            Doodle.posize = new Rectangle(230, 560, 60, 60);
            StaticEnemy.posize = new Rectangle(-200, 800, 60, 55);
            BigEnemy.posize = new Rectangle(-270, 750, 80, 70);
            movEnemy.posize = new Rectangle(20, 750,60,65);
            movEnemy.speed = new Vector2(3,0);
            r[0].posize = new Rectangle(40, 700, 60, 14);
            r[1].posize = new Rectangle(240, 640, 60, 14);
            r[2].posize = new Rectangle(400, 620, 60, 14);
            r[3].posize = new Rectangle(250, 600, 60, 14);
            r[4].posize = new Rectangle(290, 570, 60, 14);
            r[5].posize = new Rectangle(240, 550, 60, 14);
            r[6].posize = new Rectangle(200, 580, 60, 14);
            r[7].posize = new Rectangle(160, 530, 60, 14);
            r[8].posize = new Rectangle(100, 500, 60, 14);
            r[9].posize = new Rectangle(180, 460, 60, 14);
            r[10].posize = new Rectangle(270, 430, 60, 14);
            r[11].posize = new Rectangle(310, 390, 60, 14);
            r[12].posize = new Rectangle(350, 360, 60, 14);
            r[13].posize = new Rectangle(310, 320, 60, 14);
            r[14].posize = new Rectangle(310, 290, 60, 14);
            r[15].posize = new Rectangle(200, 250, 60, 14);
            r[16].posize = new Rectangle(160, 220, 60, 14);
            r[17].posize = new Rectangle(140, 180, 60, 14);
            r[18].posize = new Rectangle(400, 140, 60, 14);
            r[19].posize = new Rectangle(360, 110, 60, 14);
            r[20].posize = new Rectangle(300, 70, 60, 14);
            r[21].posize = new Rectangle(240, 40, 60, 14);
            mr[0].posize = new Rectangle(100, 335, 60, 14);
            mr[1].posize = new Rectangle(250, 15, 60, 14);
            mr[2].posize = new Rectangle(0, -20, 60, 14);
            mr[3].posize = new Rectangle(400, 630, 60, 14);
            fr[0].posize = new Rectangle(420, 435, 60, 14);
            fr[1].posize = new Rectangle(50, 120, 60, 14);
            fr[2].posize = new Rectangle(20, -35, 60, 14);
            fr[3].posize = new Rectangle(250, 525, 60, 14);
            gr[0].posize = new Rectangle(100, 263, 60, 14);
            gr[1].posize = new Rectangle(30, 330, 60, 14);
            gr[2].posize = new Rectangle(410, -50, 60, 14);
            gr[3].posize = new Rectangle(74, 660, 60, 14);
            Fanar.posize = new Rectangle(-100, 730, 20, 30);
            Trampo.posize = new Rectangle(-100, 730, 40, 18);
            Backgraound.bPosize = new Rectangle(0, -6480, 480, 7200);
            Backgraound.kPosize = new Rectangle(0, 0, 480, 720);
            Backgraound.sPosise1 = new Rectangle(0, -2880, 480, 3600);
            Backgraound.sPosise2 = new Rectangle(0, -6480, 480, 3600);
            Tir.posize = new Rectangle(-50, -50, 20, 20);
            Backgraound.bPosize.Y = -7200 + 720;
            dir = cond.Right;
            score.s = 0;
            fRnd = -1;
            tRnd = -1;
            eRnd = -1;
            Backgraound.soundCheck = true;
            Backgraound.gameStateCheck = true;
            meRnd = true;
            mecolosion = false;
            rects.Clear();
            for (int i = 0; i < 22; i++)
                rects.Add(r[i]);

        }

        public struct scor
        {
            public int s;
            public string bestS;
            public Vector2 pos;
            public SpriteFont spFont;
            public bool check;
            public void draw(SpriteBatch sp,int game)
            {
                if (game != 0 && game != 3 && game != 5)
                sp.DrawString(spFont, s.ToString(), pos, Color.White);
            }

        }

        public struct pointer
        {
            public Rectangle posize;
            public Texture2D texture;
            public void draw(SpriteBatch s)
            {
                s.Draw(texture, posize, Color.White);
            }

        }

        public void rePosition(ref List<rect> rects, ref movingRect[] mr, ref fakeRect[] fr, ref goneRect[] gr,ref movablenemy me)
        {
            int minY=500;
            rect[] temp = rects.ToArray();
            Random rnd = new Random();
            for (int i = 0; i < rects.Count; i++)
            {
                if (temp[i].posize.Y > 800)
                {
                    for (int j = 0; j < rects.Count; j++)
                        if (temp[j].posize.Y < minY) minY = temp[j].posize.Y;
                    for (int j = 0; j < 4; j++)
                    {
                        if (mr[j].posize.Y < minY) minY = mr[j].posize.Y;
                        if (fr[j].posize.Y < minY) minY = fr[j].posize.Y;
                        if (gr[j].posize.Y < minY) minY = gr[j].posize.Y;
                    }
                    if (me.posize.Y < minY) minY = me.posize.Y;
                        temp[i].posize.Y = rnd.Next(minY - 90, minY - 40);
                    temp[i].posize.X = rnd.Next(0,420);
                }
            }
            
            for (int i = 0; i < 4; i++)
            {
                if (mr[i].posize.Y > 740)
                {
                    for (int j = 0; j < rects.Count; j++)
                        if (temp[j].posize.Y < minY) minY = temp[j].posize.Y;
                    for (int j = 0; j < 4; j++)
                    {
                        if (mr[j].posize.Y < minY) minY = mr[j].posize.Y;
                        if (fr[j].posize.Y < minY) minY = fr[j].posize.Y;
                        if (gr[j].posize.Y < minY) minY = gr[j].posize.Y;
                    }
                    if (me.posize.Y < minY) minY = me.posize.Y;
                    mr[i].posize.Y = rnd.Next(minY - 80, minY - 20);
                }
                if (fr[i].posize.Y > 740)
                {
                    for (int j = 0; j < rects.Count; j++)
                        if (temp[j].posize.Y < minY) minY = temp[j].posize.Y;
                    for (int j = 0; j < 4; j++)
                    {
                        if (mr[j].posize.Y < minY) minY = mr[j].posize.Y;
                        if (fr[j].posize.Y < minY) minY = fr[j].posize.Y;
                        if (gr[j].posize.Y < minY) minY = gr[j].posize.Y;
                    }
                    if (me.posize.Y < minY) minY = me.posize.Y;
                    fr[i].posize.Y = rnd.Next(minY - 80, minY - 20);
                    fr[i].posize.X = rnd.Next(0, 420);
                }
                if (gr[i].posize.Y > 740)
                {
                    for (int j = 0; j < rects.Count; j++)
                        if (temp[j].posize.Y < minY) minY = temp[j].posize.Y;
                    for (int j = 0; j < 4; j++)
                    {
                        if (mr[j].posize.Y < minY) minY = mr[j].posize.Y;
                        if (fr[j].posize.Y < minY) minY = fr[j].posize.Y;
                        if (gr[j].posize.Y < minY) minY = gr[j].posize.Y;
                    }
                    if (me.posize.Y < minY) minY = me.posize.Y;
                    gr[i].posize.Y = rnd.Next(minY - 80, minY - 20);
                    gr[i].posize.X = rnd.Next(0, 420);
                }
            }
            if (score.s % 730 > 700 && movEnemy.posize.Y > 780)//to move and replace Movable anamy*************
            {
                for (int j = 0; j < rects.Count; j++)
                    if (temp[j].posize.Y < minY) minY = temp[j].posize.Y;
                for (int j = 0; j < 4; j++)
                {
                    if (mr[j].posize.Y < minY) minY = mr[j].posize.Y;
                    if (fr[j].posize.Y < minY) minY = fr[j].posize.Y;
                    if (gr[j].posize.Y < minY) minY = gr[j].posize.Y;
                }
                me.posize.Y = rnd.Next(minY-80,minY-70);
            }
            rects.Clear();
            rects = temp.ToList();
        }

        public KeyboardState k;
        public KeyboardState k_temp;
        public KeyboardState k_temp1;
        public MouseState m;
        public MouseState m_temp;
        public MouseState m_temp1;
        public int gameState = 0;
        public const int introMenu = 0;
        public const int gameRunning = 1;
        public const int pause = 2;
        public const int option = 3;
        public const int gameOver = 4;
        public const int hScore = 5;
        public enum cond {Left=1,Right,Tir,HeliL,HeliR,JetL,jetR,BargL,BargR}
        public scor score;
        public doodle Doodle;
        public doodle menuDoodle;
        public movablenemy movEnemy;
        public staticEnemy StaticEnemy;
        public bigEnemy BigEnemy;
        public rect[] r=new rect[22];
        public List<rect> rects = new List<rect>();
        public movingRect[] mr = new movingRect[4];
        public fakeRect[] fr = new fakeRect[4];
        public goneRect[] gr = new goneRect[4];
        public cond dir;
        public Texture2D back1;
        public background Backgraound;
        public pointer mPoint;
        public tir Tir;
        public fanar Fanar;
        public trampo Trampo;
        public sound Sound;
        public bool tirCheck;
        public bool fCheck;
        public bool collisionCheck;
        public bool tCheck;
        public bool gameover;
        public bool meRnd;
        public bool mecolosion;
        public int fRnd;//for checking fanars randoom
        public int tRnd;//for checking fanars randoom
        public int eRnd;//for checking StaticEnemies randoom
        public int e2Rnd;//for checking BigEnemies randoom

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 480;
            Content.RootDirectory = "Content";

            Doodle.posize = new Rectangle(230, 660, 60, 60);
            Doodle.speed = new Vector2(0,-13);
            menuDoodle.posize = new Rectangle(100, 520, 80, 80);
            menuDoodle.speed = new Vector2(0, -13);
            menuDoodle.ch = 0; 
            Backgraound.bPosize = new Rectangle(0,-6480,480,7200);
            Backgraound.kPosize = new Rectangle(0,0,480,720);
            Backgraound.introMenuposize = new Rectangle(0, 0, 480, 720);
            Backgraound.optionposize = new Rectangle(0, 0, 480, 720);
            Backgraound.sOnposize = new Rectangle(100, 330, 136, 45);
            Backgraound.sOffposize = new Rectangle(100, 330, 136, 45);
            Backgraound.notifposize = new Rectangle(0, 0, 480, 60);
            Backgraound.pauseposize = new Rectangle(0, 0, 480, 720);
            Backgraound.gameOverposize = new Rectangle(0, 0, 480, 720);
            Backgraound.hScoreposize = new Rectangle(0, 0, 480, 720);
            mPoint.posize = new Rectangle(0,0,20,20);
            Tir.posize = new Rectangle(-50, -50, 20, 20);
            Tir.speed = new Vector2(0, 0);
            score.pos = new Vector2(15f,4f);
            Fanar.posize=new Rectangle(-100,730,20,30);
            Trampo.posize = new Rectangle(-100,730,40,18);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Doodle.degree = 0;
            Doodle.ch = 0;
            dir = cond.Right;
            score.s = 0;
            score.bestS = "";
            tirCheck = false;
            fCheck = false;
            tCheck = false;
            collisionCheck = true;
            Sound.check = true;
            Sound.playCheck = true;
            score.check = true;
            Backgraound.soundCheck = true;
            Backgraound.gameStateCheck = true;
            mecolosion = false;
            gameover = false;
            meRnd = true;
            fRnd = -1;
            tRnd = -1;
            eRnd = -1;
            e2Rnd = -1;
            mr[0].speed = 4;
            mr[1].speed = -4;
            mr[2].speed = 3;
            mr[3].speed = 2;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            for (int i = 0; i < 22; i++)
            {
                r[i].texture = Content.Load<Texture2D>("p1");
                rects.Add(r[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                mr[i].texture = Content.Load<Texture2D>("p2");
                fr[i].texture = Content.Load<Texture2D>("p3");
                gr[i].texture = Content.Load<Texture2D>("p4");
            }
            Doodle.test = Content.Load<Texture2D>("test");
            Doodle.textureR = Content.Load<Texture2D>("DoodleR1");
            menuDoodle.textureR = Content.Load<Texture2D>("DoodleR1");
            Doodle.textureL = Content.Load<Texture2D>("DoodleL1");
            StaticEnemy.enemy = Content.Load<Texture2D>("e3");
            BigEnemy.enemy = Content.Load<Texture2D>("e2");
            movEnemy.EnemyR = Content.Load<Texture2D>("e4R");
            movEnemy.EnemyL = Content.Load<Texture2D>("e4L");
            Backgraound.back = Content.Load<Texture2D>("gradient");
            Backgraound.kooh = Content.Load<Texture2D>("kooh");
            Backgraound.introMenu = Content.Load<Texture2D>("mainMenu");
            Backgraound.option = Content.Load<Texture2D>("option");
            Backgraound.sOn = Content.Load<Texture2D>("sOn");
            Backgraound.sOff = Content.Load<Texture2D>("sOff");
            Backgraound.notif = Content.Load<Texture2D>("notif");
            Backgraound.pause = Content.Load<Texture2D>("puase");
            Backgraound.sides = Content.Load<Texture2D>("sides");
            Backgraound.gameOvre = Content.Load<Texture2D>("gameOver");
            Backgraound.hScore = Content.Load<Texture2D>("Hscore");
            Doodle.nose = Content.Load<Texture2D>("DoodleKH");
            Doodle.textureC = Content.Load<Texture2D>("DoodleT");
            mPoint.texture = Content.Load<Texture2D>("pointer");
            Tir.texture = Content.Load<Texture2D>("tir");
            score.spFont = Content.Load<SpriteFont>("SpriteFont1");
            Fanar.fanarC=Content.Load<Texture2D>("fanar");
            Fanar.fanarO=Content.Load<Texture2D>("oFanar");
            Trampo.texture = Content.Load<Texture2D>("toshak");
            Sound.Back = Content.Load<Song>("Pink");
            Sound.rect = Content.Load<Song>("shoot");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            m = Mouse.GetState();
            k = Keyboard.GetState();
            mPoint.posize.X = m.X-10;
            mPoint.posize.Y = m.Y-10;
            switch(gameState)
            {
                case gameRunning:
                    {
                        if (Doodle.posize.Y + 60 > 720) gameover = true;
                        if (Sound.playCheck && Backgraound.soundCheck)//for playiing background sound
                        {
                            MediaPlayer.Play(Sound.Back);
                            MediaPlayer.IsRepeating = true;
                            Sound.playCheck = false;
                        }
                        if (!Backgraound.soundCheck)
                        {
                            MediaPlayer.Stop();
                            Sound.playCheck = true;
                        }

                        else
                            if (Sound.playCheck)
                            {
                                MediaPlayer.Play(Sound.Back);
                                MediaPlayer.IsRepeating = true;
                                Sound.playCheck = false;
                            }
            Doodle.move();
            if (Doodle.posize.X + 10 < 0)//to prevent from exiting from sides of screen
                Doodle.posize.X = 450;
            if (Doodle.posize.X > 451)
                Doodle.posize.X = -10;

            for (int i = 0; i < 4; i++)
                mr[i].move();

            
            movEnemy.move();///////////////////////////////////////////////////
            
            if (movEnemy.Collision(Doodle,collisionCheck) == 0 && !gameover)
            {
                Doodle.speed.Y = -15;
                mecolosion = true;
            }

            else if (movEnemy.Collision(Doodle,collisionCheck) == 1)
            {
                Doodle.speed.Y = 0;
                meRnd = false;
                collisionCheck = false;
            }
            if (movEnemy.posize.Y < 780 && mecolosion)
                movEnemy.posize.Y += 11;
            else ;
            if (movEnemy.posize.Y > 785 || movEnemy.tirCollision(Tir))
            {
                meRnd = true;
                mecolosion = false;
                movEnemy.posize.X = 20;
                movEnemy.posize.Y = 800;
            }

            if (score.s % 430 > 400 && StaticEnemy.posize.Y > 780)//to move and replace StaticEnemies
            {
                do{
                Random rnd = new Random();
                eRnd = rnd.Next(1, 22);
                } while (!(rects[eRnd].posize.Y < 0));
            }
            if (eRnd != -1)
            {
                StaticEnemy.posize.Y = rects[eRnd].posize.Y - 53;
                StaticEnemy.posize.X = rects[eRnd].posize.X;
            }
            if (StaticEnemy.Collision(Doodle, collisionCheck) == 0 && !gameover)
            {
                Doodle.speed.Y = -15;
                eRnd = -1;
            }

            else if (StaticEnemy.Collision(Doodle, collisionCheck) == 1)
            {
                Doodle.speed.Y = 0;
                collisionCheck = false;
            }
            if (StaticEnemy.posize.Y < 780 && eRnd == -1)
                StaticEnemy.posize.Y += 11;
            else ;
            if (StaticEnemy.posize.Y > 795 || StaticEnemy.tirCollision(Tir))
            {
                eRnd = -1;
                StaticEnemy.posize.X = -200;
                StaticEnemy.posize.Y = 800;
            }


            if (score.s % 2030 > 2000 && BigEnemy.posize.Y > 750)//to move and replace BigEnemies
            {
                Random rnd = new Random();
                e2Rnd = rnd.Next(1, 22);
            }
            if (e2Rnd != -1)
            {
                BigEnemy.posize.Y = rects[e2Rnd].posize.Y - 68;
                BigEnemy.posize.X = rects[e2Rnd].posize.X - 5;
            }
            if (BigEnemy.Collision(Doodle) == 0 && !gameover)
            {
                Doodle.speed.Y = -15;
                BigEnemy.posize.X = -200;
            }
            else if (BigEnemy.Collision(Doodle) == 1)
            {
                Doodle.speed.Y = 0;
            }
            if (BigEnemy.posize.Y > 750)
            {
                e2Rnd = -1;
                BigEnemy.posize.X = -300;
                BigEnemy.posize.Y = 805;
            }
                        
                if (score.s % 130 > 100 && Fanar.posize.Y > 720)//to move and replace fanars
                {
                    do{
                    Random rnd = new Random();
                    fRnd = rnd.Next(0, rects.Count-1);
                    }while(!(rects[fRnd].posize.Y<0) && eRnd!=fRnd);
                }
            if (fRnd != -1)
            {
                Fanar.posize.Y = rects[fRnd].posize.Y - 30;
                Fanar.posize.X = rects[fRnd].posize.X + 10;
            }
            if (!fCheck)
            {
                fCheck = Fanar.Collision(Doodle,collisionCheck);
                if (fCheck && !gameover) Doodle.speed.Y = -18;
            }
            if (Fanar.posize.Y > 720)
            {
                fRnd = -1;
                Fanar.posize.X = -100;
                Fanar.posize.Y = 730;
                fCheck = false;
            }

            if (score.s+500 % 1030 > 1000 && Trampo.posize.Y > 720)//to move and replace tampeolines
            {
                do{
                Random rnd = new Random();
                tRnd = rnd.Next(0, rects.Count-1);
                }while(!(rects[tRnd].posize.Y<0) && tRnd!=eRnd && tRnd!=fRnd);
            }
            if (tRnd != -1)
            {
                Trampo.posize.Y = rects[tRnd].posize.Y - 15;
                Trampo.posize.X = rects[tRnd].posize.X + 10;
            }
                tCheck = Trampo.Collision(Doodle,collisionCheck);
                if (tCheck)
                {
                    Doodle.speed.Y = -23;
                    tCheck = false;
                }
            if (Trampo.posize.Y > 720)
            {
                tRnd = -1;
                Trampo.posize.X = -100;
                Trampo.posize.Y = 730;
                tCheck = false;
            }

            if (Doodle.posize.Y < 300) //to move rects and background
            {
                int speed = (int)Doodle.speed.Y;
                Doodle.posize.Y -= (int)Doodle.speed.Y;
                rect[] temp = rects.ToArray();
                for (int i = 0; i < rects.Count; i++)
                    temp[i].posize.Y -= speed;
                rects.Clear();
                rects = temp.ToList();
                for (int i = 0; i < 4; i++)
                {
                    mr[i].posize.Y -= speed;
                    fr[i].posize.Y -= speed;
                    gr[i].posize.Y -= speed;
                }
                if (movEnemy.posize.Y < 790 && meRnd)
                    movEnemy.posize.Y -= speed;

                if (Backgraound.bPosize.Y < 0)
                     Backgraound.bPosize.Y -= speed / 2;
                Backgraound.sPosise1.Y -= speed/2;
                Backgraound.sPosise2.Y -= speed/2;
                score.s -= speed / 2;
            }
            Backgraound.sideCheck();

            rePosition(ref rects,ref mr,ref fr,ref gr,ref movEnemy);//to re position rects and movable enemys
            
            for (int i = 0; i < rects.Count; i++)//to check rects coliision
                if (rects[i].Collision(Doodle) && !gameover && collisionCheck == true)
                {
                    Doodle.speed.Y = -13;
                    //MediaPlayer.Play(Sound.rect);
                }
            for (int i = 0; i < 4; i++)
            {
                if (mr[i].Collision(Doodle) && !gameover && collisionCheck == true)
                {
                    Doodle.speed.Y = -13;
                    //MediaPlayer.Play(Sound.rect);
                }
                if (fr[i].Collision(Doodle) && !gameover && collisionCheck == true)
                    fr[i].posize.X = -100;
                if (gr[i].Collision(Doodle) && !gameover && collisionCheck == true)
                {
                    Doodle.speed.Y = -13;
                    //MediaPlayer.Play(Sound.rect);
                    gr[i].posize.X = -100;
                }
            }
            k_temp1 = Keyboard.GetState();
                if (k_temp1.IsKeyDown(Keys.Escape) && !k_temp.IsKeyDown(Keys.Escape))//to go to pause menue bye esc clicking
                {
                    gameState = pause;
                    break;
                }
            k_temp = k_temp1;
            if (k.IsKeyDown(Keys.Left))//to move left and right
            {
                dir = cond.Left;
                Doodle.posize.X += -7;
            }
            else if (k.IsKeyDown(Keys.Right))
            {
                dir = cond.Right;
                Doodle.posize.X += 7;
            }
            else ;

            m = Mouse.GetState();//check mouse state for shoot and pause menu 
            if (m.LeftButton == ButtonState.Pressed && !(m_temp.LeftButton==ButtonState.Pressed))
            {
                if (m.X > 420 && m.X < 470 && m.Y > 5 && m.Y < 40)
                {
                    gameState = pause;
                    MediaPlayer.Pause();
                }
                else //to shoot tir
                {

                    if (!tirCheck && m.Y < 280)
                    {
                        Doodle.degree = (float)Math.Atan((-(m.Y - Doodle.posize.Y-27)) / (m.X - Doodle.posize.X-30));
                        Tir.posize.Y = (int)Doodle.posize.Y+27;
                        Tir.posize.X = (int)Doodle.posize.X+30;
                        if (m.X < Doodle.posize.X+30)
                        {
                            Tir.speed.Y = +25 * (float)Math.Sin(Doodle.degree);
                            Tir.speed.X = -25 * (float)Math.Cos(Doodle.degree);
                        }
                        else
                        {
                            Tir.speed.Y = -25 * (float)Math.Sin(Doodle.degree);
                            Tir.speed.X = +25 * (float)Math.Cos(Doodle.degree);
                        }
                        tirCheck = true;
                    }
                }
                
                if (Tir.posize.Y >740||Tir.posize.X<0||Tir.posize.X>480||Tir.posize.Y<0)
                    tirCheck = false;
                if(m.Y<280)
                dir = cond.Tir;
            }
            if (tirCheck && gameState==1)
                Tir.move(Doodle);

            if (Doodle.posize.Y > 720)//to end and gameovering game
                gameState = gameOver;
                    }
            break;

            case pause:
                    if (m.LeftButton == ButtonState.Pressed)
                    {
                        if (m.X > 248 && m.X < 446)
                            if (m.Y > 510 && m.Y < 570)
                            {
                                gameState = gameRunning;
                                MediaPlayer.Resume();
                            }
                        if (m.X > 280 && m.X < 458)
                            if (m.Y > 600 && m.Y < 660)
                            {
                                gameState = introMenu;
                                dir = cond.Right;
                            }
                        if (m.X > 170 && m.X < 340)
                            if (m.Y > 420 && m.Y < 480)
                            {
                                gameState = option;
                                dir = cond.Right;
                            }
                    }
                    k_temp = Keyboard.GetState();
                    if (k_temp.IsKeyDown(Keys.Escape)&& !k_temp1.IsKeyDown(Keys.Escape))
                        gameState = gameRunning;
                    k_temp1=k_temp;
                    Backgraound.gameStateCheck = false;
                    break;
                case option:
                    if (m.LeftButton == ButtonState.Pressed)
                    {
                        if (m.X > 80 && m.X < 240)
                            if (m.Y >592 && m.Y < 652)
                                if (Backgraound.gameStateCheck == true)
                                    gameState = introMenu;
                                else
                                    gameState = pause;

                        if (m.X > 100 && m.X < 160)
                            if (m.Y > 330 && m.Y < 375)
                                Backgraound.soundCheck = false;
                        if (m.X > 160 && m.X < 236)
                            if (m.Y > 330 && m.Y < 375)
                                Backgraound.soundCheck = true;
                    }
                    break;
                case introMenu:
                    m = Mouse.GetState();
                    if (m.LeftButton == ButtonState.Pressed && !(m_temp1.LeftButton == ButtonState.Pressed))
                    {
                        Backgraound.gameStateCheck = true;
                        if (m.X > 68 && m.X < 240)
                            if (m.Y > 210 && m.Y < 270)
                            {
                                m = m_temp;
                                gameState = gameRunning;
                                MediaPlayer.Resume();
                                playAgain(ref Doodle, ref score, ref rects, ref fr, ref gr, ref mr, ref Fanar, ref Trampo, ref Tir, ref Backgraound, ref gameState);
                            }
                        if (m.X > 274 && m.X < 446)
                            if (m.Y >510 && m.Y < 570 && gameState==introMenu)
                                this.Exit();
                        if (m.X >240 && m.X < 412)
                            if (m.Y > 415 && m.Y < 475)
                                gameState = option;
                        if (m.X > 200 && m.X < 365)
                            if (m.Y > 330 && m.Y < 395)
                                gameState = hScore;
                    }
                    menuDoodle.move();
                    if(menuDoodle.posize.Y>550)
                        menuDoodle.speed.Y=-13;

                    string[] bestS = System.IO.File.ReadAllLines(@"C:\Users\Meisam\Desktop\scores.txt");
                        int[] intBest = Array.ConvertAll(bestS, int.Parse);
                        Array.Sort(intBest);
                    Backgraound.hScore1 = intBest[intBest.Count() - 1];
                    Backgraound.hScore2 = intBest[intBest.Count() - 2];
                    Backgraound.hScore3 = intBest[intBest.Count() - 3];
                    Backgraound.hScore4 = intBest[intBest.Count() - 4];
                    Backgraound.hScore5 = intBest[intBest.Count() - 5];
                    break;
            case hScore:
                     m = Mouse.GetState();
                     if (m.LeftButton == ButtonState.Pressed)
                     {
                         if (m.X > 295 && m.X < 460)
                             if (m.Y > 600 && m.Y < 660)
                                 gameState = introMenu;
                     }
                    break;
            case gameOver:
                    if (score.check)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Meisam\Desktop\scores.txt", true))
                        {
                            file.WriteLine(score.s);
                        }
                        score.check = false;
                    }
                    bestS = System.IO.File.ReadAllLines(@"C:\Users\Meisam\Desktop\scores.txt");
                    intBest = Array.ConvertAll(bestS, int.Parse);
                        Array.Sort(intBest);
                    Array.Sort(intBest);
                    score.bestS = intBest[intBest.Count()-1].ToString();
                    Backgraound.hScore1 = intBest[intBest.Count() - 1];
                    Backgraound.hScore2 = intBest[intBest.Count() - 2];
                    Backgraound.hScore3 = intBest[intBest.Count() - 3];
                    Backgraound.hScore4 = intBest[intBest.Count() - 4];
                    Backgraound.hScore5 = intBest[intBest.Count() - 5];
                    if (m.LeftButton == ButtonState.Pressed)
                    {
                        if (m.X > 110 && m.X < 272)
                            if (m.Y > 467 && m.Y < 535)
                                playAgain(ref Doodle, ref score, ref rects, ref fr, ref gr, ref mr,ref Fanar,ref Trampo,ref Tir,ref Backgraound, ref gameState);
                        if (m.X > 240 && m.X < 416)
                            if (m.Y > 522 && m.Y < 612)
                            {
                                gameState = introMenu;
                                MediaPlayer.Pause();
                                dir = cond.Right;

                            }
                        m = m_temp1;
                    }
                    break;
        }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Backgraound.draw(spriteBatch,gameState,score);
            if (gameState == gameRunning)
            {
                for (int i = 0; i < rects.Count; i++)
                    rects[i].draw(spriteBatch);
                for (int i = 0; i < 4; i++)
                {
                    mr[i].draw(spriteBatch);
                    fr[i].draw(spriteBatch);
                    gr[i].draw(spriteBatch);
                }
                    Fanar.draw(spriteBatch, fCheck);
               Trampo.draw(spriteBatch);
               BigEnemy.draw(spriteBatch);
               StaticEnemy.draw(spriteBatch);
               movEnemy.draw(spriteBatch);

                // TODO: Add your drawing code here
                Doodle.draw(spriteBatch, ref dir, m,gameState);
            }
            if (gameState == introMenu)
                menuDoodle.draw(spriteBatch, ref dir, m, 1);
            Tir.draw(spriteBatch,gameState);
            Backgraound.notifdraw(spriteBatch, gameState);
            score.draw(spriteBatch,gameState);
            mPoint.draw(spriteBatch);

            spriteBatch.End();
                base.Draw(gameTime);
        }
    }
}
