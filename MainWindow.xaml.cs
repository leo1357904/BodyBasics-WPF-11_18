//------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.BodyBasics
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Media;
    using Microsoft.Kinect;
    using Microsoft.DirectX.DirectSound;
    using Microsoft.DirectX;
    using System.Runtime.InteropServices;
    using System.Text;
    
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>

    public class dragon
    {
        Uri dragonfireUri;
        public int draw_cnt;
        public int move;
        public bool appear;
        int period;
        public dragon()
        {
            draw_cnt = 0;
            period = 0;
            move = 0;
            appear = false;
        }

        public void dragon_come()
        {
            period++;
            if (appear == false)
            {
                byte[] bytes = new byte[100];
                Random rnd = new Random();
                rnd.NextBytes(bytes);
                if (bytes[0] % 255 == 0)
                {
                    appear = true;
                }

            }
            else if (draw_cnt == 150 && period == 500)
            {
                draw_cnt = 0;
                period = 0;
                appear = false;
            }

            if (appear)
            {
                draw_cnt++;
            }
        }
        public BitmapSource Drawing(char x)
        {
            if (appear)
            {
                if (x == 'd')
                {
                    if (draw_cnt < 25 | draw_cnt > 90)
                    {
                        dragonfireUri = new Uri("dragon/dragon1.png", UriKind.RelativeOrAbsolute);
                        if (draw_cnt > 0 && draw_cnt < 20)
                        {
                            move += 40;
                        }
                        if (draw_cnt > 90 && draw_cnt < 90 + 20)
                        {
                            move -= 40;
                        }
                    }
                    else if (draw_cnt < 30 | (draw_cnt > 85 && draw_cnt <= 90))
                    {
                        dragonfireUri = new Uri("dragon/dragon2.png", UriKind.RelativeOrAbsolute);
                    }
                    else if (draw_cnt < 35 | (draw_cnt > 80 && draw_cnt <= 85))
                    {
                        dragonfireUri = new Uri("dragon/dragon3.png", UriKind.RelativeOrAbsolute);
                    }
                    else if (draw_cnt <= 80)
                    {
                        dragonfireUri = new Uri("dragon/dragon4.png", UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        dragonfireUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    }
                }
                else
                {
                    if (draw_cnt < 35 | draw_cnt > 80)
                    {
                        dragonfireUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    }
                    else if (draw_cnt < 37 | draw_cnt == 79 | draw_cnt == 80)
                    {
                        dragonfireUri = new Uri("dragon/little_fire1.png", UriKind.RelativeOrAbsolute);
                    }
                    else if (draw_cnt < 39 | draw_cnt == 77 | draw_cnt == 78)
                    {
                        dragonfireUri = new Uri("dragon/little_fire2.png", UriKind.RelativeOrAbsolute);
                    }
                    else if (draw_cnt == 45)
                    {
                        dragonfireUri = new Uri("dragon/fire1.png", UriKind.RelativeOrAbsolute);
                    }
                    else if (draw_cnt % 6 < 4)
                    {
                        dragonfireUri = new Uri("dragon/fire2.png", UriKind.RelativeOrAbsolute);
                    }
                    else if (draw_cnt % 6 < 6)
                    {
                        dragonfireUri = new Uri("dragon/fire3.png", UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        dragonfireUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    }
                }
            }
            else
            {
                dragonfireUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
            }

            PngBitmapDecoder dragonfireDecoder = new PngBitmapDecoder(dragonfireUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource dragonfireSource = dragonfireDecoder.Frames[0];
            return dragonfireSource;
        }
    }

    public class shape
    {
        public int ups, lefts, rights, downs;
        Uri shape1Uri;
        public int type;

        public shape(int type, int pos)
        {
            switch (type)
            {
                case 1:
                    lefts = 190 + pos;
                    ups = 165;
                    rights = 0;
                    downs = 100;
                    break;
                case 2:
                    lefts = 63 + pos;
                    ups = 328;
                    rights = 0;
                    downs = 100;
                    break;
                case 3:
                    lefts = 275 + pos;
                    ups = 202;
                    rights = 0;
                    downs = 232;
                    break;
                case 4:
                    lefts = 64 + pos;
                    ups = 257;
                    rights = 0;
                    downs = 103;
                    break;
                case 5:
                    lefts = 205 + pos;
                    ups = 165;
                    rights = 0;
                    downs = 100;
                    break;
                case 6:
                    lefts = 767 + pos;
                    ups = 165;
                    rights = 0;
                    downs = -247;
                    break;
                case 7:
                    lefts = 667 + pos;
                    ups = 187;
                    rights = 0;
                    downs = -40;
                    break;
                case 8:
                    lefts = 268 + pos;
                    ups = 100;
                    rights = 0;
                    downs = 232;
                    break;
                case 9:
                    lefts = 600 + pos;
                    ups = 165;
                    rights = 0;
                    downs = -240;
                    break;
                case 10:
                    lefts = 1400 + pos;
                    ups = 165;
                    rights = 0;
                    downs = -230;
                    break;
            }
            this.type = type;

        }
        public BitmapSource Drawing()
        {
            switch (this.type)
            {
                case 1:
                    shape1Uri = new Uri("step.png", UriKind.RelativeOrAbsolute);
                    break;
                case 2:
                    shape1Uri = new Uri("grin.png", UriKind.RelativeOrAbsolute);
                    break;
                case 3:
                    shape1Uri = new Uri("bridge.png", UriKind.RelativeOrAbsolute);
                    break;
                case 4:
                    shape1Uri = new Uri("stick.png", UriKind.RelativeOrAbsolute);
                    break;
                case 5:
                    shape1Uri = new Uri("antistep.png", UriKind.RelativeOrAbsolute);
                    break;
                case 6:
                    shape1Uri = new Uri("antistep2.png", UriKind.RelativeOrAbsolute);
                    break;
                case 7:
                    shape1Uri = new Uri("bigstep.png", UriKind.RelativeOrAbsolute);
                    break;
                case 8:
                    shape1Uri = new Uri("final.png", UriKind.RelativeOrAbsolute);
                    break;
                    case 9:
                    shape1Uri = new Uri("stepwithhole.png", UriKind.RelativeOrAbsolute);
                    break;
                case 10:
                    shape1Uri = new Uri("stepwithbighole.png", UriKind.RelativeOrAbsolute);
                    break;
            }
            PngBitmapDecoder shape1Decoder = new PngBitmapDecoder(shape1Uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource shape1Source = shape1Decoder.Frames[0];
            return shape1Source;
        }

    }


    public class map
    {
        public int[] barrier = new int[1000];
        public bool ground_decoder; 
        public map()
        {
            ground_decoder = false;
            
            /*for (int i = 18; i <= 27; i++)
                barrier[i] = 65;

            for (int i = 48; i <= 57; i++)
                barrier[i] = 65;
            for (int i = 58; i <= 67; i++)
                barrier[i] = 130;
            for (int i = 68; i <= 77; i++)
                barrier[i] = 195;

            for (int i = 108; i <= 117; i++)
                barrier[i] = 65;

            for (int i = 128; i <= 137; i++)
                barrier[i] = 130;

            for (int i = 208; i <= 217; i++)
                barrier[i] = 65;
            for (int i = 218; i <= 262; i++)
                barrier[i] = 130;
            for (int i = 263; i <= 272; i++)
                barrier[i] = 195;

            for (int i = 273; i <= 287; i++)
                barrier[i] = -400;

            for (int i = 288; i <= 297; i++)
                barrier[i] = 195;   //HAVE TO CHANGE TO 3LEVELS 
            for (int i = 298; i <= 307; i++)
                barrier[i] = 130;

            for (int i = 308; i <= 317; i++)
                barrier[i] = -400;

            for (int i = 318; i <= 327; i++)
                barrier[i] = 195;

            for (int i = 328; i <= 337; i++)
                barrier[i] = -400;

            for (int i = 338; i <= 347; i++)
                barrier[i] = 195;

            for (int i = 348; i <= 357; i++)
                barrier[i] = -400;

            for (int i = 358; i <= 367; i++)
                barrier[i] = 195;

            for (int i = 368; i <= 377; i++)
                barrier[i] = -400;



            for (int i = 378; i <= 387; i++)
                barrier[i] = 65;
            for (int i = 388; i <= 397; i++)
                barrier[i] = 130;
            for (int i = 398; i <= 407; i++)
                barrier[i] = 195;

            for (int i = 408; i <= 417; i++)
                barrier[i] = -400;

            
            for (int i = 418; i <= 427; i++)
                barrier[i] = 195;  //HAVE TO CHANGE TO 3LEVELS 
            for (int i = 428; i <= 437; i++)
                barrier[i] = 130;
            for (int i = 438; i <= 447; i++)
                barrier[i] = 65;

            for (int i = 468; i <= 477; i++)
                barrier[i] = 65;

            for (int i = 498; i <= 507; i++)
                barrier[i] = 65;
            */
            for (int i = 528; i <= 537; i++)
                barrier[i] = 65;
            for (int i = 538; i <= 547; i++)
                barrier[i] = 130;
            for (int i = 548; i <= 554; i++)
                barrier[i] = 195;
            /*
            for (int i = 555; i <= 569; i++)
                barrier[i] = -400;//0
            */
            for (int i = 570; i <= 682; i++)
                barrier[i] = 195;
        }


    }

    public class Bossbullet
    {
        public int counter;
        public int counterMAX;
        public int X, Y;
        public int number;
        public bool notused;
        public bool empty;
        public bool shooting;
        Uri bulletUri;
        public int positionx;

        public Bossbullet()
        {
            number = -1;
            counterMAX = 120;//42*40
            counter = 0;
            X = 0;
            Y = 130;
            positionx = 645;
            empty = true;
            shooting = false;
            notused = true;
        }
        public void ALLreset()
        {
            number = -1;
            counterMAX = 120;//42*40
            counter = 0;
            X = 0;
            Y = 130;
            positionx = 645;
            empty = true;
            shooting = false;
            notused = true;
        }

        public BitmapSource Draw(int type)
        {
            switch (type)
            {
                case 0: bulletUri = new Uri("freezebullet.png", UriKind.RelativeOrAbsolute); break;
                case 1: bulletUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute); break;
            }
            PngBitmapDecoder bulletDecoder = new PngBitmapDecoder(bulletUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bulletSource = bulletDecoder.Frames[0];

            if (counter < counterMAX)
            {
                X += 28;
                //X++;
                positionx -= 2;
                counter++;
            }

            return bulletSource;
        }

        public void reset()
        {
            counter = 0;
            X = 0;
            Y = 0;
            positionx = 645;
            shooting = false;
            notused = true;
        }


    }

    public class bullet
    {
        public int counter;
        public int counterMAX;
        public int X,Y;
        public bool direction;
        public int number;
        public bool notused;
        public bool empty;
        public bool shooting;
        Uri bulletUri;
        public int positionx;
        public bool pad; 

        public bullet()
        {
            number = -1;
            counterMAX = 40;//42*40
            counter = 0;
            X = 0;
            Y = 0;
            positionx = 0;
            empty = true;
            direction = false;
            shooting = false;
            notused = true;
            pad = false;
        }
        public void ALLreset()
        {
            number = -1;
            counterMAX = 40;//42*40
            counter = 0;
            X = 0;
            Y = 0;
            positionx = 0;
            empty = true;
            direction = false;
            shooting = false;
            notused = true;
            pad = false;
        }

        public void setValue(int horizen,int mariopositionx, bool mariodirection, bool marioshooting){
            Y = horizen;
            positionx = mariopositionx;
            direction = mariodirection;
            shooting = marioshooting;
        }

        public BitmapSource shoot()
        {
            if (direction){
                bulletUri = new Uri("firebulletR.png", UriKind.RelativeOrAbsolute);
            }else{
                bulletUri = new Uri("firebulletL.png", UriKind.RelativeOrAbsolute);
            }

            PngBitmapDecoder bulletDecoder = new PngBitmapDecoder(bulletUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bulletSource = bulletDecoder.Frames[0];

            if(counter<counterMAX){
                X +=42;
                //X++;
                if (direction)
                {
                    positionx += 3;
                }
                else
                {
                    positionx -= 3;
                }
                counter++;
            }
            
            return bulletSource;
        }

        public void reset() {
            counter = 0;
            X = 0;
            Y = 0;
            positionx = 0;
            direction = false;
            shooting = false;
            notused = true;
        }

        public void padding(char state, double ER, double HR, double EL, double HL){
            if (state == 'w' && (( HR > ER+40)&&( HL > EL+40))) {
                number = 6;
                empty = false;
                pad = true;
            }
            else if (number == 6)
            {
                pad = false;
            }
        }
    }

    public class mouse
    {
        Uri mouseUri;
        public float x;
        public float y;
        public int state;
        public mouse()
        {
            x = 0;
            y = -200;
            state = 0;
        }
        public void if_attack(HandState HR)
        {


            if (HR == HandState.Open)
            {
                state = 0;
            }

            else if (HR == HandState.Closed)
            {
                state = 1;
            }
        }
        public BitmapSource Drawing(int type)
        {
            switch(type)
            {
                case 0:
                    mouseUri = new Uri("mouse.png", UriKind.RelativeOrAbsolute);
                    break;
                case 1:
                    mouseUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    break;

            }
            PngBitmapDecoder marioDecoder = new PngBitmapDecoder(mouseUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource marioSource = marioDecoder.Frames[0];
            return marioSource;
        }
    }
    public class start
    {
        Uri mouseUri;

        public start()
        {
        }
        
        public BitmapSource Drawing(int state)
        {
            
            switch(state)
            {
                case 0:
                    mouseUri = new Uri("start.png", UriKind.RelativeOrAbsolute);
                    break;
                case 1:
                    mouseUri = new Uri("start-play.png", UriKind.RelativeOrAbsolute);
                    break;
                case 2:
                    mouseUri = new Uri("start-quit.png", UriKind.RelativeOrAbsolute);
                    break;
                case 3:
                    mouseUri = new Uri("gameover.png", UriKind.RelativeOrAbsolute);
                    break;
                case 4:
                    mouseUri = new Uri("gameover-quit.png", UriKind.RelativeOrAbsolute);
                    break;
                case 5:
                    mouseUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    break;
                case 6:
                    mouseUri = new Uri("congratulations.png", UriKind.RelativeOrAbsolute);
                    break;
                case 7:
                    mouseUri = new Uri("congratulations_big.png", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    mouseUri = new Uri("start.png", UriKind.RelativeOrAbsolute);
                    break;

            }
            
            PngBitmapDecoder marioDecoder = new PngBitmapDecoder(mouseUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource marioSource = marioDecoder.Frames[0];
            return marioSource;
        }
    }




    public class player
    {
        public int positionx;
        public int positiony;
        public bool isjump;
        public int jumpCNT;
        public int jumpCNT_half;
        public int jumpHeight;
        public int horizen;
        public int lefts, ups, rirgts, downs; //left side ,
        public double top;
        public bool direction; // rihgt =1 left=0
        public bool shooting;
        public int hp;
        Uri marioUri;
        public int walk_cnt;
        public int last_posx;
        public int curr_posx;
        public bool isfall;

        public char state; // n=normal w=weapon s=stop
        public player()
        {
            state = 's';
            isjump = false;
            jumpCNT = 15;
            jumpHeight = 13;
            horizen = 0;
            top = 0;
            direction = false; // rihgt =1 left=0
            lefts = 0;
            ups = 160;
            rirgts = 0;
            downs = 130;
            shooting = false;
            positionx = 0;
            positiony = 0;
            hp = 3;
            walk_cnt = 0;
            last_posx = 0;
            curr_posx = 0;
            isfall = false;
        }

        public void ALLreset()
        {
            state = 's';
            isjump = false;
            jumpCNT = 15;
            jumpHeight = 13;
            horizen = 0;
            top = 0;
            direction = false; // rihgt =1 left=0
            lefts = 0;
            ups = 160;
            rirgts = 0;
            downs = 130;
            shooting = false;
            positionx = 0;
            positiony = 0;
            hp = 3;
            walk_cnt = 0;
            last_posx = 0;
            curr_posx = 0;
            isfall = false;
        }

        public BitmapSource Drawing(int time)
        {
            int temp = (time / 4) % 2;
            curr_posx = last_posx;
            last_posx = positionx;

            if (direction)
            {
                if (temp == 1){
                    if (state == 'w')
                    {
                        marioUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        marioUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    }
                }
                else{
                    if (state == 'w'){
                        marioUri = new Uri("marioR-gun.png", UriKind.RelativeOrAbsolute);
                    }
                    else{
                        if (isfall || isjump)
                        {
                            marioUri = new Uri("jumpR.png", UriKind.RelativeOrAbsolute);
                        }
                        else if (walk_cnt > 4)
                        {
                            marioUri = new Uri("marioR.png", UriKind.RelativeOrAbsolute);
                        }
                        else
                        {
                            marioUri = new Uri("marioR2.png", UriKind.RelativeOrAbsolute);
                        }
                    }
                }
            }
            else
            {
                if (temp == 1)
                {
                    if (state == 'w')
                    {
                        marioUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        marioUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    }
                }
                else
                {
                    if (state == 'w')
                    {
                        marioUri = new Uri("marioL-gun.png", UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        
                        if(isfall || isjump){
                            marioUri = new Uri("jumpL.png", UriKind.RelativeOrAbsolute);
                        }
                        else if (walk_cnt >4){
                            marioUri = new Uri("marioL.png", UriKind.RelativeOrAbsolute);
                        }
                        else{
                            marioUri = new Uri("marioL2.png", UriKind.RelativeOrAbsolute);
                        }
                    }
                }
            }
            if (last_posx != curr_posx)
                walk_cnt++;
            if (walk_cnt == 9) walk_cnt = 0;
            PngBitmapDecoder marioDecoder = new PngBitmapDecoder(marioUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource marioSource = marioDecoder.Frames[0];
            return marioSource;
        }

        public void if_jump(double head)
        {
            if (head > top) top = head;
            if (top - 20 > head && isjump == false && (state!='s'))
            {
                
                isjump = true;
                top = 0;
            }
        }
        
        public void jump(int barrierhHeight)
        {
            if (isjump && jumpCNT > 0)
            {
                if (jumpCNT > jumpCNT_half)
                {
                    horizen += jumpHeight;
                }
                jumpCNT--;
            }
            else if (isjump)
            {
                if (horizen > barrierhHeight)
                    horizen -= jumpHeight;
                else
                {
                    jumpCNT = 15;
                    isjump = false;
                }
            }
            else
            {

                if (horizen > barrierhHeight)
                {
                    isfall = true;
                    horizen -= jumpHeight;
                }
                else
                {
                    isfall = false;
                }
            }
        }
        public void if_attack(HandState HR,HandState HL)
        {
            if (state != 'w' )
            {
                if ((HR == HandState.Open) || (HL == HandState.Open))
                {
                    state = 'w';
                }
            }
            else if (!(HR == HandState.Open) || (HL == HandState.Open))
            {
                state = 'n';
            }
        }

        public void attack(double rightS,double rightH,double leftS,double leftH)
        {

            if (!shooting && ((rightH + 20 < rightS) || (leftH + 20 < leftS)))
            {
                //music.Play();
                shooting = true;
            }
        }



        public void position_update()
        {
            this.ups = 360-horizen;
            this.downs = 100 + horizen;
            return;
        }

    }

    public class monster
    {
        public int position;
        public int horizen;
        public bool direction; // rihgt =1 left=0
        public int lefts, ups, rirgts, downs;
        public int cnt;
        public int cntt;
        public bool chase;  // 1 = chase
        public int chase_flag;
        public int mposition; //mario position
        public bool istouched;
        Uri monsterUri;

        public monster(int left, int up, int right, int down, int pos, int height,bool enable_chase)
        {
            position = pos;
            horizen = height;
            direction = false;
            lefts = left;
            rirgts = right;
            ups = up;//325
            downs = down;//75
            cnt = 0;
            cntt = 4;
            chase = enable_chase;
            chase_flag = 0;
            mposition = 0;
            istouched = false;
        }
        public void ALLreset(int left, int up, int right, int down, int pos, int height)
        {
            position = pos;
            horizen = height;
            direction = false;
            lefts = left;
            rirgts = right;
            ups = up;//325
            downs = down;//75
            cnt = 0;
            cntt = 4;
            chase_flag = 0;
            mposition = 0;
            istouched = false;
        }

        public BitmapSource Drawing()
        {
            int sub = mposition - position; //distance

            switch (chase)
            {   
                case false :
                    if (cnt <= 16) { direction = false; rirgts += 5; cnt++; if (cnt == 16) cntt = 0; }
                    else if (cntt <= 17) { direction = true; rirgts -= 5; cntt++; if (cntt == 17) cnt = 0; }

                    if (direction)
                        monsterUri = new Uri("monsterR.png", UriKind.RelativeOrAbsolute);
                    else
                        monsterUri = new Uri("monsterL.png", UriKind.RelativeOrAbsolute);
                    break;
                case true :
                    if ( 0 <= sub )
                    {
                        rirgts -= 5;
                        chase_flag++;
                        if (chase_flag == 3)
                        {
                            position++;
                            chase_flag = 0;
                        }
                        direction = true;
                        monsterUri = new Uri("monsterR.png", UriKind.RelativeOrAbsolute);

                    }
                    else if ( sub < 0 )
                    {
                        if (cnt <= 16) { direction = false; rirgts += 5; cnt++; if (cnt == 16) cntt = 0; }
                        else if (cntt <= 17) { direction = true; rirgts -= 5; cntt++; if (cntt == 17) cnt = 0; }

                        if (direction)
                            monsterUri = new Uri("monsterR.png", UriKind.RelativeOrAbsolute);
                        else
                            monsterUri = new Uri("monsterL.png", UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        if (cnt <= 16) { direction = false; rirgts += 5; cnt++; if (cnt == 16) cntt = 0; }
                        else if (cntt <= 17) { direction = true; rirgts -= 5; cntt++; if (cntt == 17) cnt = 0; }

                        if (direction)
                            monsterUri = new Uri("monsterR.png", UriKind.RelativeOrAbsolute);
                        else
                            monsterUri = new Uri("monsterL.png", UriKind.RelativeOrAbsolute);
                    }


                    break;
            }
            //if (direction) direction = false;
            //else direction = true;
            PngBitmapDecoder monsterDecoder = new PngBitmapDecoder(monsterUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource monsterSource = monsterDecoder.Frames[0];
            return monsterSource;
        }

        public bool Checkdeath(int player, int mon)
        {
            if (player == mon) //gif try
            {
                return true;
            }
            return false;
        }

        public void GetMarioPosition(int mpos)
        {
            mposition = mpos;
        }


    }

    public class Boss
    {
        public bool exist;
        public int hp;
        public int position;
        public int horizen;
        public int lefts, ups, rirgts, downs;
        public int seq, seq_cnt;
        Uri bossUri;

        public Boss()
        {
            exist = false;
            hp = 5;
            position = 645;
            horizen = 415;
            lefts = 9150;
            rirgts = 30;
            ups = 100;//325
            downs = 290;//75
            seq = 2;
            seq_cnt = 0;
        }
        public void ALLreset()
        {
            exist = false;
            hp = 5;
            position = 645;
            horizen = 415;
            lefts = 9150;
            rirgts = 30;
            ups = 100;
            downs = 290;
            seq = 2;
            seq_cnt = 0;
            bossUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
        }

        public BitmapSource Drawing(int type)//1 for reset
        {
            switch (type)
            {
                case 0:
                    bossUri = new Uri("boss.png", UriKind.RelativeOrAbsolute);
                    break;
                case 1:
                    bossUri = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                    break;
                case 2:
                    bossUri = new Uri("light2.png", UriKind.RelativeOrAbsolute);
                    seq_cnt++;
                    if (seq_cnt == 10)
                    {
                        seq = 3;
                        seq_cnt = 0;
                    }
                    break;
                case 3:
                    bossUri = new Uri("light3.png", UriKind.RelativeOrAbsolute);
                    seq_cnt++;
                    if (seq_cnt == 10)
                    {
                        seq = 4;
                        seq_cnt = 0;
                    }
                    break;
                case 4:
                    bossUri = new Uri("light4.png", UriKind.RelativeOrAbsolute);
                    seq_cnt++;
                    if (seq_cnt == 10)
                    {
                        seq = 0;
                        seq_cnt = 0;
                    }
                    break;
            }
                PngBitmapDecoder bossDecoder = new PngBitmapDecoder(bossUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bossSource = bossDecoder.Frames[0];
                return bossSource;
        }


    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Radius of drawn hand circles
        /// </summary>
        private const double HandSize = 30;
       
        /// <summary>
        /// Thickness of drawn joint lines
        /// </summary>
        private const double JointThickness = 3;

        /// <summary>
        /// Thickness of clip edge rectangles
        /// </summary>
        private const double ClipBoundsThickness = 10;

        /// <summary>
        /// Constant for clamping Z values of camera space points from being negative
        /// </summary>
        private const float InferredZPositionClamp = 0.1f;

        /// <summary>
        /// Brush used for drawing hands that are currently tracked as closed
        /// </summary>
        private readonly Brush handClosedBrush = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));

        /// <summary>
        /// Brush used for drawing hands that are currently tracked as opened
        /// </summary>
        private readonly Brush handOpenBrush = new SolidColorBrush(Color.FromArgb(128, 0, 255, 0));

        /// <summary>
        /// Brush used for drawing hands that are currently tracked as in lasso (pointer) position
        /// </summary>
        private readonly Brush handLassoBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 255));

        /// <summary>
        /// Brush used for drawing joints that are currently tracked
        /// </summary>
        private readonly Brush trackedJointBrush = new SolidColorBrush(Color.FromArgb(255, 68, 192, 68));

        /// <summary>
        /// Brush used for drawing joints that are currently inferred
        /// </summary>        
        private readonly Brush inferredJointBrush = Brushes.Yellow;

        /// <summary>
        /// Pen used for drawing bones that are currently inferred
        /// </summary>        
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);

        /// <summary>
        /// Drawing group for body rendering output
        /// </summary>
        private DrawingGroup drawingGroup;

        /// <summary>
        /// Drawing image that we will display
        /// </summary>
        private DrawingImage imageSource;

        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor kinectSensor = null;

        /// <summary>
        /// Coordinate mapper to map one type of point to another
        /// </summary>
        private CoordinateMapper coordinateMapper = null;

        /// <summary>
        /// Reader for body frames
        /// </summary>
        private BodyFrameReader bodyFrameReader = null;

        /// <summary>
        /// Array for the bodies
        /// </summary>
        private Body[] bodies = null;

        /// <summary>
        /// definition of bones
        /// </summary>
        private List<Tuple<JointType, JointType>> bones;

        /// <summary>
        /// Width of display (depth space)
        /// </summary>
        private int displayWidth;

        /// <summary>
        /// Height of display (depth space)
        /// </summary>
        private int displayHeight;

        /// <summary>
        /// List of colors for each body tracked
        /// </summary>
        private List<Pen> bodyColors;

        /// <summary>
        /// Current status text to display
        /// </summary>
        private string statusText = null;
        
        //------------color


        //---------------color
        ///
        public int move = 50;
        public int moveleft = 0;
        public int moveright = 0;
        public bool can_linedraw = true;
      
        player mario =new player();
        mouse mouse = new mouse();
        monster mob  = new monster(0, 325, -2200, 75 , 150, 160, true);
        monster mob2 = new monster(0, 200, -3200, 200, 220, 290, false);
        monster mob3 = new monster(0, 200, -3700, 200, 255, 290, false);
        monster mob4 = new monster(0, 120, -4600, 280, 320, 350, false);
        monster mob5 = new monster(0, 120, -5700, 280, 400, 350, false);
        monster mob6 = new monster(0, 120, -6000, 280, 420, 350, false);
        Boss boss = new Boss();
        Bossbullet bossbullet = new Bossbullet();
        Uri bosshp;

        int time_invincible = 0;
        
        bullet bulletA =new bullet();
        public int handX, handY;
        Uri checkUri;
        SoundPlayer main_music = new SoundPlayer("main_music.wav");
        SoundPlayer start_music = new SoundPlayer("start_music.wav");
        SoundPlayer boss_music = new SoundPlayer("boss_music.wav");
        SoundPlayer pass_music = new SoundPlayer("m_pass.wav");
        SoundPlayer end_music = new SoundPlayer("m_end.wav");
        bool main_music_p = false;
        bool start_music_p = false;
        bool boss_music_p = false;
        bool pass_music_p = false;
        bool end_music_p = false;

        public int state = 0;
        public int[,] barrierindex = new int[,] { { 0, 0 }, { 2, 280 }, { 1, 700 }, { 2, 1540 }, { 4, 1820 }, { 7, 2940 }, { 6, 4060 }, { 3, 4480 }, { 9, 5320 }, { 5, 5880 }, { 2, 6580 }, { 2, 7000 }, { 10, 7420 }, { 3, 7980 } ,{8,8820} };
        public int barriercount = 6;
        public int tempcount1 = 1;
        public int tempcount2 = 2;
        public int tempcount3 = 3;
        public int tempcount4 = 4;
        public int tempcount5 = 5;
        public int tempcount6 = 6;
        map map1 = new map();
        start start = new start();
        dragon dragonA = new dragon();

        Uri bgAUri;
        BitmapSource bgASource;
        int end_delay = 50;

        double calcute_fps = 0;
        int fps = 0;
        int show_fps = 0;
        int temp3 = 0;
        int startcount = 0;
       // public const int MM_MCINOTIFY = 0x3B9;
       
        [DllImport("Winmm.dll")]
        public static extern int mciSendString(
         string lpszCommand,
          string lpszReturnString,
          int cchReturn,
          IntPtr hwndCallback
        );
 
        public void PlayMusic(string MusicPath)//播放背景音乐  
        {
            mciSendString("stop \"" + MusicPath + "\" ", null, 0, IntPtr.Zero);
            mciSendString("play \"" + MusicPath + "\" ", null, 0, IntPtr.Zero);
            
        }  

        /***********
         ** DEPTH **
         ***********/

        /// <summary>
        /// Map depth range to byte range
        /// </summary>
        private const int MapDepthToByte = 8000 / 256;

        /// <summary>
        /// Reader for depth frames
        /// </summary>
        private DepthFrameReader depthFrameReader = null;

        /// <summary>
        /// Description of the data contained in the depth frame
        /// </summary>
        private FrameDescription depthFrameDescription = null;

        /// <summary>
        /// Bitmap to display
        /// </summary>
        private WriteableBitmap depthBitmap = null;

        /// <summary>
        /// Intermediate storage for frame data converted to color
        /// </summary>
        private byte[] depthPixels = null;

        /*****/

        private ColorFrameReader colorFrameReader = null;

        /// <summary>
        /// Bitmap to display
        /// </summary>
        private WriteableBitmap colorBitmap = null;
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
          
            // one sensor is currently supported
            this.kinectSensor = KinectSensor.GetDefault();

            // get the coordinate mapper
            this.coordinateMapper = this.kinectSensor.CoordinateMapper;

            // get the depth (display) extents
            FrameDescription frameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;

            // get size of joint space
            this.displayWidth = frameDescription.Width;
            this.displayHeight = frameDescription.Height;

            // open the reader for the body frames
            this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();

            // a bone defined as a line between two joints
            this.bones = new List<Tuple<JointType, JointType>>();

            // Torso
            this.bones.Add(new Tuple<JointType, JointType>(JointType.Head, JointType.Neck));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.Neck, JointType.SpineShoulder));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.SpineMid));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineMid, JointType.SpineBase));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipLeft));

            // Right Arm
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderRight, JointType.ElbowRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowRight, JointType.WristRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.HandRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HandRight, JointType.HandTipRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.ThumbRight));

            // Left Arm
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderLeft, JointType.ElbowLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowLeft, JointType.WristLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.HandLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HandLeft, JointType.HandTipLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.ThumbLeft));

            // Right Leg
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HipRight, JointType.KneeRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeRight, JointType.AnkleRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleRight, JointType.FootRight));

            // Left Leg
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HipLeft, JointType.KneeLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeLeft, JointType.AnkleLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleLeft, JointType.FootLeft));

            // populate body colors, one for each BodyIndex
            this.bodyColors = new List<Pen>();

            this.bodyColors.Add(new Pen(Brushes.Red, 6));
            this.bodyColors.Add(new Pen(Brushes.Orange, 6));
            this.bodyColors.Add(new Pen(Brushes.Green, 6));
            this.bodyColors.Add(new Pen(Brushes.Blue, 6));
            this.bodyColors.Add(new Pen(Brushes.Indigo, 6));
            this.bodyColors.Add(new Pen(Brushes.Violet, 6));



            /***********
             ** DEPTH **
             ***********/
            // open the reader for the depth frames
            this.depthFrameReader = this.kinectSensor.DepthFrameSource.OpenReader();

            // wire handler for frame arrival
            this.depthFrameReader.FrameArrived += this.Reader_DepthFrameArrived;

            // get FrameDescription from DepthFrameSource
            this.depthFrameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;

            // allocate space to put the pixels being received and converted
            this.depthPixels = new byte[this.depthFrameDescription.Width * this.depthFrameDescription.Height];

            // create the bitmap to display
            this.depthBitmap = new WriteableBitmap(this.depthFrameDescription.Width, this.depthFrameDescription.Height, 96.0, 96.0, PixelFormats.Gray8, null);

            /************/


            //-----
            // open the reader for the color frames
            this.colorFrameReader = this.kinectSensor.ColorFrameSource.OpenReader();

            // wire handler for frame arrival
            this.colorFrameReader.FrameArrived += this.Reader_ColorFrameArrived;

            // create the colorFrameDescription from the ColorFrameSource using Bgra format
            FrameDescription colorFrameDescription = this.kinectSensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Bgra);

            // create the bitmap to display
            this.colorBitmap = new WriteableBitmap(colorFrameDescription.Width, colorFrameDescription.Height, 96.0, 96.0, PixelFormats.Bgr32, null);

            //---

            // set IsAvailableChanged event notifier
            this.kinectSensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;

            // open the sensor
            this.kinectSensor.Open();

            // set the status text
            this.StatusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
                                                            : Properties.Resources.NoSensorStatusText;

            // Create the drawing group we'll use for drawing
            this.drawingGroup = new DrawingGroup();

            // Create an image source that we can use in our image control
            this.imageSource = new DrawingImage(this.drawingGroup);

            // use the window object as the view model in this simple example
            this.DataContext = this;
            // initialize the components (controls) of the window
            this.InitializeComponent();

            
        }
  
        /// <summary>
        /// INotifyPropertyChangedPropertyChanged event to allow window controls to bind to changeable data
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the bitmap to display
        /// </summary>
        public ImageSource ImageSource
        {
            get
            {
                return this.imageSource;
            }
        }

        /// <summary>
        /// Gets the bitmap to display
        /// </summary>
        public ImageSource DepthImageSource
        {
            get
            {
                return this.colorBitmap;
            }
        }


        /// <summary>
        /// Gets or sets the current status text to display
        /// </summary>
        public string StatusText
        {
            get
            {
                return this.statusText;
            }

            set
            {
                if (this.statusText != value)
                {
                    this.statusText = value;

                    // notify any bound elements that the text has changed
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("StatusText"));
                    }
                }
            }
        }

        /// <summary>
        /// Execute start up tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // ----------check------
            if (mario.state == 's')
            {
                checkUri = new Uri("redblock.png", UriKind.RelativeOrAbsolute);
            }
            else if (mario.state == 'n' || mario.state == 'w')
            {
                checkUri = new Uri("greenblock.png", UriKind.RelativeOrAbsolute);
            }
            else
            {
                checkUri = new Uri("redblock.png", UriKind.RelativeOrAbsolute);
            }

            PngBitmapDecoder checkDecoder = new PngBitmapDecoder(checkUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource checkSource = checkDecoder.Frames[0];
            check.Source = checkSource;
            check.Margin = new Thickness(0, 460, 1080, -30);
            // ----------check------

            if (this.bodyFrameReader != null)
            {
                this.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;
            }
        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (this.colorFrameReader != null)
            {
                // ColorFrameReder is IDisposable
                this.colorFrameReader.Dispose();
                this.colorFrameReader = null;
            }

            if (this.bodyFrameReader != null)
            {
                // BodyFrameReader is IDisposable
                this.bodyFrameReader.Dispose();
                this.bodyFrameReader = null;
            }

            if (this.depthFrameReader != null)
            {
                // DepthFrameReader is IDisposable
                this.depthFrameReader.Dispose();
                this.depthFrameReader = null;
            }

            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
                this.kinectSensor = null;
            }


        }

        /// <summary>
        /// Handles the body frame data arriving from the sensor
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
           
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            bool dataReceived = false;

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                    {
                        this.bodies = new Body[bodyFrame.BodyCount];
                    }

                    // The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
                    // As long as those body objects are not disposed and not set to null in the array,
                    // those body objects will be re-used.
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                    dataReceived = true;
                }
            }

            if (dataReceived)
            {
                using (DrawingContext dc = this.drawingGroup.Open())
                
                {
                    int penIndex = 0;

                    foreach (Body body in this.bodies)
                    {
                        Pen drawPen = this.bodyColors[penIndex++];

                        if (body.IsTracked)
                        {
                           // this.DrawClippedEdges(body, dc);

                            IReadOnlyDictionary<JointType, Joint> joints = body.Joints;

                            // convert the joint points to depth (display) space
                            Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();

                            foreach (JointType jointType in joints.Keys)
                            {
                                // sometimes the depth(Z) of an inferred joint may show as negative
                                // clamp down to 0.1f to prevent coordinatemapper from returning (-Infinity, -Infinity)
                                CameraSpacePoint position = joints[jointType].Position;
                                if (position.Z < 0)
                                {
                                    position.Z = InferredZPositionClamp;
                                }

                                DepthSpacePoint depthSpacePoint = this.coordinateMapper.MapCameraPointToDepthSpace(position);
                                jointPoints[jointType] = new Point(depthSpacePoint.X, depthSpacePoint.Y);
                            }

                            this.DrawBody(joints, jointPoints, dc, drawPen);

                            this.DrawHand(body.HandLeftState, jointPoints[JointType.HandLeft], dc);
                            this.DrawHand(body.HandRightState, jointPoints[JointType.HandRight], dc);

                            // ----------check------
                            if (mario.state == 's')
                            {
                                checkUri = new Uri("redblock.png", UriKind.RelativeOrAbsolute);
                            }
                            else if (mario.state == 'n' || mario.state == 'w')
                            {
                                checkUri = new Uri("greenblock.png", UriKind.RelativeOrAbsolute);
                            }
                            else
                            {
                                checkUri = new Uri("redblock.png", UriKind.RelativeOrAbsolute);
                            }
                            PngBitmapDecoder checkDecoder = new PngBitmapDecoder(checkUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                            BitmapSource checkSource = checkDecoder.Frames[0];
                            check.Source = checkSource;
                            check.Margin = new Thickness(0, 460, 1080, -30);
                            // ----------check------
                            
                            //line
                            Joint body_HRjoint = body.Joints[JointType.HandRight];
                            DepthSpacePoint dpoint_HR = this.coordinateMapper.MapCameraPointToDepthSpace(body_HRjoint.Position);
                            Point pHR = new Point(dpoint_HR.X, dpoint_HR.Y);

                            Joint body_ERjoint = body.Joints[JointType.ElbowRight];
                            DepthSpacePoint dpoint_ER = this.coordinateMapper.MapCameraPointToDepthSpace(body_ERjoint.Position);
                            Point pER = new Point(dpoint_ER.X, dpoint_ER.Y);

                            Joint body_ELjoint = body.Joints[JointType.ElbowLeft];
                            DepthSpacePoint dpoint_EL = this.coordinateMapper.MapCameraPointToDepthSpace(body_ELjoint.Position);
                            Point pEL = new Point(dpoint_EL.X, dpoint_EL.Y);

                            //
                            Joint body_HLjoint = body.Joints[JointType.HandLeft];
                            DepthSpacePoint dpoint_HL = this.coordinateMapper.MapCameraPointToDepthSpace(body_HLjoint.Position);
                            Point pHL = new Point(dpoint_HL.X, dpoint_HL.Y);

                            Joint body_SLjoint = body.Joints[JointType.ShoulderLeft];
                            DepthSpacePoint dpoint_SL = this.coordinateMapper.MapCameraPointToDepthSpace(body_SLjoint.Position);
                            Point pSL = new Point(dpoint_SL.X, dpoint_SL.Y);

                            Joint body_SRjoint = body.Joints[JointType.ShoulderRight];
                            DepthSpacePoint dpoint_SR = this.coordinateMapper.MapCameraPointToDepthSpace(body_SRjoint.Position);
                            Point pSR = new Point(dpoint_SR.X, dpoint_SR.Y);

                            //
                             if (state == 0 || state==2 || state == 3)
                            {
                                mouse.x = body.Joints[JointType.HandRight].Position.X *2000+500;
                                mouse.y = (body.Joints[JointType.HandRight].Position.Y)*2000-600 ;
                                if (mouse.x > 1200 || mouse.x < -1200)
                                {
                                    mouse.x = (mouse.x > 0) ? 1200 : -1200;
                                }
                                if (mouse.y > 0 || mouse.y < -600)
                                {
                                    mouse.y = (mouse.y > 0) ? 0 : -600;
                                }
                                mouse.if_attack(body.HandRightState);
                            }

                            
                            if (state == 1)
                            {
                            mario.if_attack(body.HandRightState, body.HandLeftState);
                            
                            if ( !((-10 < pHR.X - pER.X) && (pHR.X - pER.X < 10))){
                                int temp = 0;
                                
                                if ((pHR.X > pER.X) ||(pER.X <pEL.X))
                                {
                                    for (int i = 0; i <= 5; i++)
                                    {
                                        if (mario.positionx >= 2 && map1.barrier[mario.positionx + i] > temp)
                                        {
                                            temp = map1.barrier[mario.positionx + i];
                                        }
                                    }
                                    if (temp <= mario.horizen && mario.state == 'n' && end_delay==50)
                                    {
                                        if (moveleft > 0)
                                        {
                                            moveleft = moveleft - 14;
                                            mario.positionx++;
                                        }
                                        else if (move > 8730)
                                        {
                                            moveright += 14;
                                            mario.positionx++;
                                        }
                                        else
                                        {
                                            move = move + 14;
                                            mario.positionx++;
                                        }
                                        
                                    }
                                    mario.direction = true;
                                }
                                else
                                {
                                    temp = 0;
                                    for (int i = 0; i <= 5; i++)
                                    {
                                        if (mario.positionx >=5 && map1.barrier[mario.positionx - i] > temp)
                                        {
                                            temp = map1.barrier[mario.positionx - i];
                                        }
                                    }
                                    if (mario.positionx != 0 && temp <= mario.horizen && mario.state == 'n'&&end_delay==50)
                                    {
                                        //move = move -14;
                                        moveleft = moveleft + 14;
                                        mario.positionx--;
                                    }
                                    mario.direction = false;
                                }
                            }
                            //str.Text = "SR: " + pSR.Y.ToString() + "  HR: " + pHR.Y.ToString();
                            if (mario.state == 'w')
                            {
                                mario.attack(pSR.Y,pHR.Y,pSL.Y,pHL.Y);
                            }
                           
                            bulletA.padding(mario.state,pER.Y,pHR.Y,pEL.Y,pHL.Y);
                            if (bulletA.pad)
                            {
                                PlayMusic("padding.mp3");
                            }

                            Joint body_Headjoint = body.Joints[JointType.Head];
                            DepthSpacePoint dpoint_Head = this.coordinateMapper.MapCameraPointToDepthSpace(body_Headjoint.Position);
                            Point pHead = new Point(dpoint_Head.X, dpoint_Head.Y);

                            handX = (int)dpoint_SR.X;
                            handY = (int)dpoint_SR.Y;

                            mario.if_jump(pHead.Y);
                            if (mario.isjump&& (mario.jumpCNT==15))
                            {
                                PlayMusic("jump.mp3");
                            }

                            }
                        }
                    }
                    if (state == 0)
                    {
                        //過關或失敗後關音樂
                        pass_music_p = false;
                        if (!start_music_p)
                        {
                            start_music.Play();
                            start_music_p = true;
                        }


                        mouseImg.Source = mouse.Drawing(0);

                        mouseImg.Margin = new Thickness(0 + mouse.x, 0 - mouse.y, 0, 600 + mouse.y);
                       // str.Text=" x :  "+mouse.x.ToString() + "  y:" + mouse.y.ToString()+" count :" + state.ToString();

                        startcount++;
                        if (mouse.x > -300 && mouse.x < 300 && mouse.y > -400 && mouse.y < -300)
                        {
                            gameoverImg.Source = start.Drawing(1);
                            if (mouse.state == 1 && startcount > 50)
                            {
                                state = 1;
                                mouse.state = 0;
                                gameoverImg.Source = start.Drawing(5);
                                mouseImg.Source = mouse.Drawing(1);
                                startcount = 0;
                            }
                        
                        }
                        else if (mouse.x > -300 && mouse.x < 300 && mouse.y > -500 && mouse.y < -400)
                        {
                            gameoverImg.Source = start.Drawing(2);
                            if (mouse.state == 1 && startcount>50)
                            {
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            gameoverImg.Source = start.Drawing(0);
                        }
                        
                        gameoverImg.Margin = new Thickness(0, 0, 0, 0);
                    }

                    if (state == 1){
                        //show  HP
                        //mario.horizen = 400;


                        start_music_p = false;
                        end_music_p = false;
                        if (!main_music_p)
                        {
                            main_music.Play();
                            main_music_p = true;
                        }

                        if (mario.positionx == 660)
                        {
                            state = 3;
                        }
                        else if (mario.horizen < -300)
                        {
                            state = 2;
                            PlayMusic("mariodead.mp3");
                        }
                        Uri showHP;
                        switch (mario.hp)
                        {
                            case 1:
                                showHP = new Uri("hp1.png", UriKind.RelativeOrAbsolute);
                                break;
                            case 2:
                                showHP = new Uri("hp2.png", UriKind.RelativeOrAbsolute);
                                break;
                            case 3:
                                showHP = new Uri("hp3.png", UriKind.RelativeOrAbsolute);
                                break;
                            default:
                                showHP = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                                break;
                        }
                        PngBitmapDecoder showHPDecoder = new PngBitmapDecoder(showHP, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        BitmapSource showHPSource = showHPDecoder.Frames[0];
                        hpImg.Source = showHPSource;
                        hpImg.Margin = new Thickness(0, 10, 20, 550);

                   
                        //SHOW BULLET
                        Uri showbullet;
                        switch(bulletA.number){
                            case 1:
                                showbullet = new Uri("bulletM1.png", UriKind.RelativeOrAbsolute);
                                break;
                            case 2:
                                showbullet = new Uri("bulletM2.png", UriKind.RelativeOrAbsolute);
                                break;
                            case 3:
                                showbullet = new Uri("bulletM3.png", UriKind.RelativeOrAbsolute);
                                break;
                            case 4:
                                showbullet = new Uri("bulletM4.png", UriKind.RelativeOrAbsolute);
                                break;
                            case 5:
                                showbullet = new Uri("bulletM5.png", UriKind.RelativeOrAbsolute);
                                break;
                            case 6:
                                showbullet = new Uri("bulletM6.png", UriKind.RelativeOrAbsolute);
                                break;
                            default:
                                showbullet = new Uri("bulletM0.png", UriKind.RelativeOrAbsolute);
                                break;
                        }
                        PngBitmapDecoder showbulletDecoder = new PngBitmapDecoder(showbullet, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        BitmapSource showbulletSource = showbulletDecoder.Frames[0];
                        showbulletImg.Source = showbulletSource;
                        //showbulletImg.Margin = new Thickness(0, -20, 400, 430);
                        showbulletImg.Margin = new Thickness(0,0,1000,500);

                        //-----
                        //---------------temp1 for jump
                        int temp1=-2000;
                        for (int i = 0; i <= 5; i++)
                        {
                            if(mario.positionx>=2 && map1.barrier[mario.positionx-2+i ]> temp1)
                            {
                                temp1 = map1.barrier[mario.positionx-2+i];
                            }            
                            else if (mario.positionx<2)
                            {
                                temp1 = 0;
                            }
                        }

                        //----
                        if (mario.shooting && (!bulletA.empty))
                        {
                            if (!bulletA.shooting){
                                bulletA.setValue(mario.horizen,mario.positionx, mario.direction, mario.shooting);
                            }
                            
                            if ((bulletA.counter == (bulletA.counterMAX-2) ) ||(bulletA.notused==false)
                                || bulletA.empty)
                            { //not shoot
                                //str.Text = "                          NOT ";
                                if (bulletA.number == 0) bulletA.empty = true;
                                mario.shooting = false;
                                bulletImg.Margin = new Thickness(0, 0, 0, 3000);
                                bulletA.reset();
                            }
                            else //shoot ing
                            {
                                //str.Text = "                          GO ";
                                bulletImg.Source = bulletA.shoot();
                                if (bulletA.counter > 3)
                                {
                                    bulletImg.Margin = new Thickness(0, 385 - bulletA.Y, moveleft + ((bulletA.direction) ? (-bulletA.X) : bulletA.X), 155 + bulletA.Y);
                                }
                                else
                                {
                                    bulletImg.Margin = new Thickness(0, 0, 0, 3000);
                                }
                            }

                            if (bulletA.counter == 3)
                            {
                                
                                PlayMusic("gun.mp3");
                                bulletA.number--;
                
                            }

                            int temp = bulletA.positionx +( (bulletA.direction) ? 2 : 2);
                            if (temp < 0) temp = 0;
                            if ((bulletA.Y + 85 < map1.barrier[temp]))
                            {
                                bulletA.notused = false;
                            }
                        }
                        //str.Text += "v_bX : "+v_bulletX.ToString()+"  v_bY :"+ v_bulletY.ToString()+"  v_baI :"+ v_barIndex.ToString()+"  v_vaY :"+ v_barY.ToString();
                        //----sheng-sheng-lin----

                        Uri skyUri = new Uri("sky.png", UriKind.RelativeOrAbsolute);
                        PngBitmapDecoder skyDecoder = new PngBitmapDecoder(skyUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        BitmapSource skySource = skyDecoder.Frames[0];
                        sky.Source = skySource;
                        sky.Margin = new Thickness(10000, 0, 10000, 0);

                       



                        if (map1.ground_decoder == false)
                        {
                            bgAUri = new Uri("groundV.png", UriKind.RelativeOrAbsolute);
                            PngBitmapDecoder bgADecoder = new PngBitmapDecoder(bgAUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                            bgASource = bgADecoder.Frames[0];
                            map1.ground_decoder = true;
                        }

                        backgroundA.Source = bgASource;
                        backgroundA.Margin = new Thickness(5575 - move, 400, 0, 7);
                        backgroundB.Source = bgASource;
                        backgroundB.Margin = new Thickness(1600 - move, 400, 0, 7);
                        //backgroundC.Source = bgASource;
                        //backgroundC.Margin = new Thickness(7950 - move, 400, 0, 7);
                        Uri boardUri = new Uri("board.png", UriKind.RelativeOrAbsolute);

                        PngBitmapDecoder boardDecoder = new PngBitmapDecoder(boardUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        BitmapSource boardSource = boardDecoder.Frames[0];
                        boardImg.Source = boardSource;
                        if (move < 1200)
                        {
                            boardImg.Margin = new Thickness(0 - move, 370, 240, 95);
                        }
                        else if (move <4500)
                        {
                            boardImg.Margin = new Thickness(3000 - move, 370, 240, 95);
                        }
                        else
                        {
                            boardImg.Margin = new Thickness(7500 - move, 370, 240, 95);
                        }

                        if (barriercount != 14 && barrierindex[barriercount + 1, 1] < move + 1400)
                        {
                            barriercount++;
                            switch (barriercount % 6)
                            {
                                case 0:
                                    tempcount1 = barriercount - 5;
                                    tempcount2 = barriercount - 4;
                                    tempcount3 = barriercount - 3;
                                    tempcount4 = barriercount - 2;
                                    tempcount5 = barriercount - 1;
                                    tempcount6 = barriercount;
                                    break;
                                case 1:
                                    tempcount1 = barriercount;
                                    tempcount2 = barriercount - 5;
                                    tempcount3 = barriercount - 4;
                                    tempcount4 = barriercount - 3;
                                    tempcount5 = barriercount - 2;
                                    tempcount6 = barriercount - 1;
                                    break;
                                case 2:
                                    tempcount1 = barriercount - 1;
                                    tempcount2 = barriercount;
                                    tempcount3 = barriercount - 5;
                                    tempcount4 = barriercount - 4;
                                    tempcount5 = barriercount - 3;
                                    tempcount6 = barriercount - 2;
                                    break;
                                case 3:
                                    tempcount1 = barriercount - 2;
                                    tempcount2 = barriercount - 1;
                                    tempcount3 = barriercount;
                                    tempcount4 = barriercount - 5;
                                    tempcount5 = barriercount - 4;
                                    tempcount6 = barriercount - 3;
                                    break;
                                case 4:
                                    tempcount1 = barriercount - 3;
                                    tempcount2 = barriercount - 2;
                                    tempcount3 = barriercount - 1;
                                    tempcount4 = barriercount;
                                    tempcount5 = barriercount - 5;
                                    tempcount6 = barriercount - 4;
                                    break;
                                case 5:
                                    tempcount1 = barriercount - 4;
                                    tempcount2 = barriercount - 3;
                                    tempcount3 = barriercount - 2;
                                    tempcount4 = barriercount - 1;
                                    tempcount5 = barriercount;
                                    tempcount6 = barriercount - 5;
                                    break;
                            }
                        }
                        shape shape2 = new shape(barrierindex[tempcount1, 0], barrierindex[tempcount1, 1]);
                        barrier1.Source = shape2.Drawing();
                        barrier1.Margin = new Thickness(shape2.lefts - move, shape2.ups, shape2.rights, shape2.downs);

                        shape shape1 = new shape(barrierindex[tempcount2, 0], barrierindex[tempcount2, 1]);
                        barrier2.Source = shape1.Drawing();
                        barrier2.Margin = new Thickness(shape1.lefts - move, shape1.ups, shape1.rights, shape1.downs);

                        shape shape3 = new shape(barrierindex[tempcount3, 0], barrierindex[tempcount3, 1]);
                        barrier3.Source = shape3.Drawing();
                        barrier3.Margin = new Thickness(shape3.lefts - move, shape3.ups, shape3.rights, shape3.downs);

                        shape shape4 = new shape(barrierindex[tempcount4, 0], barrierindex[tempcount4, 1]);
                        barrier4.Source = shape4.Drawing();
                        barrier4.Margin = new Thickness(shape4.lefts - move, shape4.ups, shape4.rights, shape4.downs);

                        shape shape5 = new shape(barrierindex[tempcount5, 0], barrierindex[tempcount5, 1]);
                        barrier5.Source = shape5.Drawing();
                        barrier5.Margin = new Thickness(shape5.lefts - move, shape5.ups, shape5.rights, shape5.downs);

                        shape shape6 = new shape(barrierindex[tempcount6, 0], barrierindex[tempcount6, 1]);
                        barrier6.Source = shape6.Drawing();
                        barrier6.Margin = new Thickness(shape6.lefts - move, shape6.ups, shape6.rights, shape6.downs);

                            
                        mario.jump(temp1);
                        marioImg.Source = mario.Drawing(time_invincible);
                        mario.position_update();
                        marioImg.Margin = new Thickness(mario.lefts + moveright, mario.ups, 13 + mario.rirgts + moveleft, mario.downs);
                        
                        // dragon 
                        dragonA.dragon_come();
                        dragonImg.Source = dragonA.Drawing('d');
                        dragonImg.Margin = new Thickness(1031 - dragonA.move, 0, 0, 0);//+800
                        fireImg.Source = dragonA.Drawing('f');
                        fireImg.Margin = new Thickness(0, 0, 190, 0);
                        // str.Text = dragonA.draw_cnt.ToString();
                        if (dragonA.draw_cnt == 45 && time_invincible == 0)
                        {
                            mario.hp--;
                            time_invincible++;
                        }

                        //------monster
                        mob.mposition = mario.positionx;
                        monsterImg.Source = mob.Drawing();
                        monsterImg.Margin = new Thickness(mob.lefts, mob.ups, mob.rirgts + move, mob.downs);
                        if ((mob.position == bulletA.positionx || mob.position == bulletA.positionx + 1 || mob.position == bulletA.positionx + 2) && bulletA.Y+85 < mob.horizen && bulletA.notused)
                        {   mob.position = -100; mob.ups = 20000; mob.downs = -10000;
                            bulletA.notused = false;
                            PlayMusic("monsterdead.mp3");
                        }
                        if (mob.position - 3 <= mario.positionx && mario.positionx <= mob.position + 3 && mario.horizen < mob.horizen && time_invincible == 0)
                        { mario.hp--; time_invincible++; }
                        

                        monsterImg2.Source = mob2.Drawing();
                        monsterImg2.Margin = new Thickness(mob2.lefts, mob2.ups, mob2.rirgts + move, mob2.downs);
                        if ((mob2.position == bulletA.positionx || mob2.position == bulletA.positionx + 1 || mob2.position == bulletA.positionx + 2) && bulletA.Y+85 < mob2.horizen && bulletA.notused)
                        {
                            mob2.position = -100; mob2.ups = 20000; mob2.downs = -10000;
                            bulletA.notused = false;
                            PlayMusic("monsterdead.mp3");
                        }
                        if (mob2.position - 3 <= mario.positionx && mario.positionx <= mob2.position + 3 && mario.horizen < mob2.horizen && time_invincible == 0)
                        { mario.hp--; time_invincible++; }

                        monsterImg3.Source = mob3.Drawing();
                        monsterImg3.Margin = new Thickness(mob3.lefts, mob3.ups, mob3.rirgts + move, mob3.downs);
                        if ((mob3.position == bulletA.positionx || mob3.position == bulletA.positionx + 1 || mob3.position == bulletA.positionx + 2) && bulletA.Y + 85 < mob3.horizen && bulletA.notused)
                        {
                            mob3.position = -100; mob3.ups = 20000; mob3.downs = -10000;
                            bulletA.notused = false;
                            PlayMusic("monsterdead.mp3");
                        }
                        if (mob3.position - 3 <= mario.positionx && mario.positionx <= mob3.position + 3 && mario.horizen < mob3.horizen && time_invincible == 0)
                        { mario.hp--; time_invincible++; }

                        monsterImg4.Source = mob4.Drawing();
                        monsterImg4.Margin = new Thickness(mob4.lefts, mob4.ups, mob4.rirgts + move, mob4.downs);
                        if ((mob4.position == bulletA.positionx || mob4.position == bulletA.positionx + 1 || mob4.position == bulletA.positionx + 2) && bulletA.Y + 85 < mob4.horizen && bulletA.notused)
                        {
                            mob4.position = -100; mob4.ups = 20000; mob4.downs = -10000;
                            bulletA.notused = false;
                            PlayMusic("monsterdead.mp3");
                        } 
                        if (mob4.position - 3 <= mario.positionx && mario.positionx <= mob4.position + 3 && mario.horizen < mob4.horizen && mario.horizen != 0 && time_invincible == 0)
                        { mario.hp--; time_invincible++; }

                        monsterImg5.Source = mob5.Drawing();
                        monsterImg5.Margin = new Thickness(mob5.lefts, mob5.ups, mob5.rirgts + move, mob5.downs);
                        if ((mob5.position == bulletA.positionx || mob5.position == bulletA.positionx + 1 || mob5.position == bulletA.positionx + 2) && bulletA.Y + 85 < mob5.horizen && bulletA.notused)
                        {
                            mob5.position = -100; mob5.ups = 20000; mob5.downs = -10000;
                            bulletA.notused = false;
                            PlayMusic("monsterdead.mp3");
                        }
                        if (mob5.position - 3 <= mario.positionx && mario.positionx <= mob5.position + 3 && mario.horizen < mob5.horizen && time_invincible == 0)
                        { mario.hp--; time_invincible++; }

                        monsterImg6.Source = mob6.Drawing();
                        monsterImg6.Margin = new Thickness(mob6.lefts, mob6.ups, mob6.rirgts + move, mob6.downs);
                        if ((mob6.position == bulletA.positionx || mob6.position == bulletA.positionx + 1 || mob6.position == bulletA.positionx + 2) && bulletA.Y + 85 < mob6.horizen && bulletA.notused)
                        {
                            mob6.position = -100; mob6.ups = 20000; mob6.downs = -10000;
                            bulletA.notused = false;
                            PlayMusic("monsterdead.mp3");
                        }
                        if (mob6.position - 3 <= mario.positionx && mario.positionx <= mob6.position + 3 && mario.horizen < mob6.horizen && time_invincible == 0)
                        { mario.hp--; time_invincible++; }

                        if (time_invincible == 40) time_invincible = 0;
                        else if (time_invincible > 0) time_invincible++;

                        //------ boss
                        if (!boss.exist && mario.positionx > 567 && boss.hp > 0 ) boss.exist = true;
                        if (boss.exist)
                        {
                            bossImg.Source = boss.Drawing(boss.seq);
                            if ( boss.seq == 0 )    bossImg.Margin = new Thickness(boss.lefts - move, boss.ups, boss.rirgts, boss.downs);
                            else bossImg.Margin = new Thickness(boss.lefts - move-50, boss.ups-20, boss.rirgts-50, boss.downs-200);
                        }


                        if (boss.exist && ( !boss_music_p))
                        {
                            boss_music.Play();
                            boss_music_p = true;
                        }

                        //------ bossbullet
                        if (boss.exist)
                        {

                            if (bossbullet.counter == bossbullet.counterMAX)
                            {
                                bossbullet.reset();
                                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                                int r = rnd.Next() % 5;
                                switch (r)
                                {
                                    case 0:
                                        bossbullet.Y = 195;
                                        break;
                                    case 1:
                                        bossbullet.Y = 195;
                                        break;
                                    case 2:
                                        bossbullet.Y = 130;
                                        break;
                                    case 3:
                                        bossbullet.Y = 130;
                                        break;
                                    case 4:
                                        bossbullet.Y = 130;
                                        break;
                                }
                                PlayMusic("bossgun.mp3");
                            }
                            if( boss.hp == 0 ) bossbulletImg.Source = bossbullet.Draw(1);
                            else bossbulletImg.Source = bossbullet.Draw(0);

                            if (bossbullet.counter > 3)
                                bossbulletImg.Margin = new Thickness(0, 385 - bossbullet.Y, move - 9100 + bossbullet.X, 155 + bossbullet.Y);
                            else
                                bossbulletImg.Margin = new Thickness(0, 0, 0, 3000);

                            //---bullet meet
                            if ((bossbullet.Y) > (bulletA.Y - 5) && (bossbullet.Y) < (bulletA.Y + 5) && (bossbullet.positionx <= bulletA.positionx + 3 && bossbullet.positionx >= bulletA.positionx - 3))
                            {
                                bulletA.notused = false; bossbullet.Y = -5000; bossbullet.positionx = 0;
                                PlayMusic("bulletcollision.mp3");
                            }
                            //---boss been shot
                            if ((bulletA.positionx >= boss.position - 3) && (bulletA.positionx <= boss.position + 3) && (bulletA.Y + 85) <= boss.horizen + 5)
                            {
                                boss.hp--; bulletA.notused = false;
                                PlayMusic("bosshurt.mp3");
                            }
                            //---mario been shot
                            //str.Text = "bbh :  " + bossbullet.Y.ToString() + "mh : " + mario.horizen.ToString() + "bbp : " + bossbullet.positionx.ToString() + "mp : " + mario.positionx.ToString();
                            if ((bossbullet.positionx >= mario.positionx - 2) && (bossbullet.positionx <= mario.positionx + 2) && (bossbullet.Y + 65 >= mario.horizen - 5) && (bossbullet.Y + 65 <= mario.horizen + 90))
                            {
                                bossbullet.Y = -5000; bossbullet.positionx = 0; mario.hp--;
                                time_invincible++;
                               // PlayMusic("bosshurt.mp3");
                            }

                            switch (boss.hp)
                            {
                                case 0:
                                    if (boss.exist)
                                    {
                                        PlayMusic("bossdead.mp3");
                                    }
                                    bosshp = new Uri("bosshealth0.png", UriKind.RelativeOrAbsolute);
                                    boss.exist = false;
                                    bossImg.Source = boss.Drawing(1);
                                    break;
                                case 1:
                                    bosshp = new Uri("bosshealth1.png", UriKind.RelativeOrAbsolute);
                                    break;
                                case 2:
                                    bosshp = new Uri("bosshealth2.png", UriKind.RelativeOrAbsolute);
                                    break;
                                case 3:
                                    bosshp = new Uri("bosshealth3.png", UriKind.RelativeOrAbsolute);
                                    break;
                                case 4:
                                    bosshp = new Uri("bosshealth4.png", UriKind.RelativeOrAbsolute);
                                    break;
                                case 5:
                                    bosshp = new Uri("bosshealth5.png", UriKind.RelativeOrAbsolute);
                                    break;
                            }
                            PngBitmapDecoder bosshpDecoder = new PngBitmapDecoder(bosshp, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                            BitmapSource bosshpSource = bosshpDecoder.Frames[0];
                            bosshpImg.Source = bosshpSource;
                            bosshpImg.Margin = new Thickness(100, 550, 0, 0);
                        }

                        //---------------------
                        can_linedraw = false;


                        if (mario.hp <= 0 )
                        {
                            end_delay--;
                            mario.state = 's';
                            if(end_delay==45)
                                PlayMusic("mariodead.mp3");
                        }

                        if ((mario.hp <= 0) && (end_delay == 0))
                        {
                            end_delay = 50;
                            //PlayMusic("mariodead.mp3");
                            state = 2;
                        }
                         
                        // prevent drawing outside of our render area
                        this.drawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0, this.displayWidth, this.displayHeight));
                
                    }


                    
                    if (state == 2){
                        mouseImg.Source = mouse.Drawing(0);
                        mouseImg.Margin = new Thickness(0 + mouse.x, 0 - mouse.y, 0, 600 + mouse.y);
                       // str.Text = "                    x :  " + mouse.x.ToString() + "  y:" + mouse.y.ToString() + " count :" +state.ToString();

                        if (!end_music_p && main_music_p) {
                            end_music.Play();
                        }
                        main_music_p = false;
                        if (mouse.x > -300 && mouse.x < 300 && mouse.y > -600 && mouse.y < -400)
                        {
                            gameoverImg.Source = start.Drawing(4);
                            if (mouse.state == 1)
                            {
                                main_music_p = false;
                                start_music_p = false;
                                boss_music_p = false;
                                pass_music_p = false;
                                end_music_p = false;
                                state = 1;
                                mouse.state = 0;
                                time_invincible = 0;
                                boss.ALLreset();
                                bossImg.Source = boss.Drawing(1);
                                bossbullet.ALLreset();
                                bosshp = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                                PngBitmapDecoder bosshpDecoder = new PngBitmapDecoder(bosshp, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                                BitmapSource bosshpSource = bosshpDecoder.Frames[0];
                                bosshpImg.Source = bosshpSource;
                                bosshpImg.Margin = new Thickness(100, 550, 0, 0);
                                mob .ALLreset(0, 325, -2200, 75, 150, 160);
                                mob2.ALLreset(0, 200, -3200, 200, 220, 290);
                                mob3.ALLreset(0, 200, -3700, 200, 255, 290);
                                mob4.ALLreset(0, 120, -4600, 280, 320, 350);
                                mob5.ALLreset(0, 120, -5700, 280, 400, 350);
                                mob6.ALLreset(0, 120, -6000, 280, 420, 350);
                                mario.ALLreset();
                                marioImg.Source = mario.Drawing(0);
                                bulletA.ALLreset();
                                move = 50;
                                moveleft = 0;
                                moveright = 0;
                                barriercount = 6;
                                tempcount1 = 1;
                                tempcount2 = 2;
                                tempcount3 = 3;
                                tempcount4 = 4;
                                tempcount5 = 5;
                                tempcount6 = 6;
                                mouseImg.Source = mouse.Drawing(1);
                                gameoverImg.Source = start.Drawing(5);
                                
                            }
                        }
                        else
                        {
                            gameoverImg.Source = start.Drawing(3);
                        }

                        gameoverImg.Margin = new Thickness(0, 0, 0, 0);
                    }
                    if (state == 3)
                    {
                        mouseImg.Source = mouse.Drawing(0);
                        mouseImg.Margin = new Thickness(0 + mouse.x, 0 - mouse.y, 0, 600 + mouse.y);
                        //str.Text = "                    x :  " + mouse.x.ToString() + "  y:" + mouse.y.ToString() + " count :" + state.ToString();
                        if (!pass_music_p && main_music_p)
                        {
                            pass_music.Play();
                        }
                        main_music_p = false;

                        if (mouse.x > -300 && mouse.x < 300 && mouse.y > -600 && mouse.y < -400)
                        {
                            gameoverImg.Source = start.Drawing(7);
                            if (mouse.state == 1)
                            {
                                main_music_p = false;
                                start_music_p = false;
                                boss_music_p = false;
                                pass_music_p = false;
                                end_music_p = false;
                                state = 0;
                                mouse.state = 0;
                                time_invincible = 0;
                                boss.ALLreset();
                                bossImg.Source = boss.Drawing(1);
                                bossbullet.ALLreset();
                                bosshp = new Uri("hp0.png", UriKind.RelativeOrAbsolute);
                                PngBitmapDecoder bosshpDecoder = new PngBitmapDecoder(bosshp, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                                BitmapSource bosshpSource = bosshpDecoder.Frames[0];
                                bosshpImg.Source = bosshpSource;
                                bosshpImg.Margin = new Thickness(100, 550, 0, 0);
                                mob.ALLreset(0, 325, -2200, 75, 150, 160);
                                mob2.ALLreset(0, 200, -3200, 200, 220, 290);
                                mob3.ALLreset(0, 200, -3700, 200, 255, 290);
                                mob4.ALLreset(0, 120, -4600, 280, 320, 355);
                                mob5.ALLreset(0, 120, -5700, 280, 400, 355);
                                mob6.ALLreset(0, 120, -6000, 280, 420, 355);
                                mario.ALLreset();
                                marioImg.Source = mario.Drawing(0);
                                bulletA.ALLreset();
                                move = 50;
                                moveleft = 0;
                                moveright = 0;
                                barriercount = 6;
                                tempcount1 = 1;
                                tempcount2 = 2;
                                tempcount3 = 3;
                                tempcount4 = 4;
                                tempcount5 = 5;
                                tempcount6 = 6;
                                mouseImg.Source = mouse.Drawing(1);
                                gameoverImg.Source = start.Drawing(5);

                            }
                        }
                        else
                        {
                            gameoverImg.Source = start.Drawing(6);
                        }

                        gameoverImg.Margin = new Thickness(0, 0, 0, 0);
                    }


                }
            }



            double result1 = sw.Elapsed.TotalMilliseconds;
            calcute_fps += result1;
            fps++;

            if (calcute_fps > 10)
            {
                show_fps = fps;
                calcute_fps = 0;
                fps = 0;
            }
            //str.Text = "posx :  " + handX.ToString() + "   fps " + handY.ToString() + "  en delay " + temp3.ToString() + " mario s:";
            //text
            //str.Text +=  "  /X:" + mario.positionx.ToString() + "  /H:" + mario.horizen +" rps: " + show_fps + " /Bshoot: " + mario.shooting.ToString() + bulletA.shooting.ToString() ;

        }

        private void Reader_DepthFrameArrived(object sender, DepthFrameArrivedEventArgs e)
        {
            bool depthFrameProcessed = false;

            using (DepthFrame depthFrame = e.FrameReference.AcquireFrame())
            {
                if (depthFrame != null)
                {
                    // the fastest way to process the body index data is to directly access 
                    // the underlying buffer
                    using (Microsoft.Kinect.KinectBuffer depthBuffer = depthFrame.LockImageBuffer())
                    {
                        // verify data and write the color data to the display bitmap
                        if (((this.depthFrameDescription.Width * this.depthFrameDescription.Height) == (depthBuffer.Size / this.depthFrameDescription.BytesPerPixel)) &&
                            (this.depthFrameDescription.Width == this.depthBitmap.PixelWidth) && (this.depthFrameDescription.Height == this.depthBitmap.PixelHeight))
                        {
                            // Note: In order to see the full range of depth (including the less reliable far field depth)
                            // we are setting maxDepth to the extreme potential depth threshold
                            ushort maxDepth = ushort.MaxValue;

                            // If you wish to filter by reliable depth distance, uncomment the following line:
                            //// maxDepth = depthFrame.DepthMaxReliableDistance

                            this.ProcessDepthFrameData(depthBuffer.UnderlyingBuffer, depthBuffer.Size, depthFrame.DepthMinReliableDistance, maxDepth);
                            depthFrameProcessed = true;
                        }
                    }
                }
            }

            if (depthFrameProcessed)
            {
                this.RenderDepthPixels();
            }
        }

        private void Reader_ColorFrameArrived(object sender, ColorFrameArrivedEventArgs e)
        {
            // ColorFrame is IDisposable
            using (ColorFrame colorFrame = e.FrameReference.AcquireFrame())
            {
                if (colorFrame != null)
                {
                    FrameDescription colorFrameDescription = colorFrame.FrameDescription;

                    using (KinectBuffer colorBuffer = colorFrame.LockRawImageBuffer())
                    {
                        this.colorBitmap.Lock();

                        // verify data and write the new color frame data to the display bitmap
                        if ((colorFrameDescription.Width == this.colorBitmap.PixelWidth) && (colorFrameDescription.Height == this.colorBitmap.PixelHeight))
                        {
                            colorFrame.CopyConvertedFrameDataToIntPtr(
                                this.colorBitmap.BackBuffer,
                                (uint)(colorFrameDescription.Width * colorFrameDescription.Height * 4),
                                ColorImageFormat.Bgra);

                            this.colorBitmap.AddDirtyRect(new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight));
                        }

                        this.colorBitmap.Unlock();
                    }
                }
            }
        }

        private unsafe void ProcessDepthFrameData(IntPtr depthFrameData, uint depthFrameDataSize, ushort minDepth, ushort maxDepth)
        {
            // depth frame data is a 16 bit value
            ushort* frameData = (ushort*)depthFrameData;

            temp3 = this.depthBitmap.PixelWidth * (handY) + handX;
            ushort catch_depth;

            if (temp3< 180000)
            {
                catch_depth=frameData[temp3];
            }
            else
            {
                catch_depth = 350;
            }

            if ((catch_depth > 400) && (catch_depth < 2500))
            {
                mario.state = 'n';
            }
            else
            {
                mario.state = 's';
            }
            //mario.state = 'n';
            // convert depth to a visual representation
            for (int i = 0; i < (int)(depthFrameDataSize / this.depthFrameDescription.BytesPerPixel); ++i)
            {
                // Get the depth for this pixel
                ushort depth = frameData[i];

                // To convert to a byte, we're mapping the depth value to the byte range.
                // Values outside the reliable depth range are mapped to 0 (black).
               //if (i== temp)
               //{
               //
               //    this.depthPixels[i] = (byte)(depth >= minDepth && depth <= maxDepth ? (255) : 0);
               //    if ((depth > 1000) && (depth < 2500)){
               //        mario.state = 'n';
               //    }
               //    else {
               //        mario.state = 's';
               //    }
               //}
               //else
               //{
                    this.depthPixels[i] = (byte)(depth >= minDepth && depth <= maxDepth ? (depth / MapDepthToByte) : 0);
               // }
            }
        }

        private void RenderDepthPixels()
        {
            this.depthBitmap.WritePixels(
                new Int32Rect(0, 0, this.depthBitmap.PixelWidth, this.depthBitmap.PixelHeight),
                this.depthPixels,
                this.depthBitmap.PixelWidth,
                0);
        }


 
        private void DrawBody(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, DrawingContext drawingContext, Pen drawingPen)
        {
            // Draw the bones
            foreach (var bone in this.bones)
            {
                this.DrawBone(joints, jointPoints, bone.Item1, bone.Item2, drawingContext, drawingPen);
            }
            can_linedraw = true;
            
            // Draw the joints
            foreach (JointType jointType in joints.Keys)
            {
                Brush drawBrush = null;

                TrackingState trackingState = joints[jointType].TrackingState;

                if (trackingState == TrackingState.Tracked)
                {
                    drawBrush = this.trackedJointBrush;
                }
                else if (trackingState == TrackingState.Inferred)
                {
                    drawBrush = this.inferredJointBrush;
                }

                if (drawBrush != null)
                {
                  //  drawingContext.DrawEllipse(drawBrush, null, jointPoints[jointType], JointThickness, JointThickness);
                    
                    
                }
            }

           
        }


        private void DrawBone(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, JointType jointType0, JointType jointType1, DrawingContext drawingContext, Pen drawingPen)
        {
            Joint joint0 = joints[jointType0];
            Joint joint1 = joints[jointType1];

            // If we can't find either of these joints, exit
            if (joint0.TrackingState == TrackingState.NotTracked ||
                joint1.TrackingState == TrackingState.NotTracked)
            {
                return;
            }

            // We assume all drawn bones are inferred unless BOTH joints are tracked
            Pen drawPen = this.inferredBonePen;
            if ((joint0.TrackingState == TrackingState.Tracked) && (joint1.TrackingState == TrackingState.Tracked))
            {
                drawPen = drawingPen;
            }

           // drawingContext.DrawLine(drawPen, jointPoints[jointType0], jointPoints[jointType1]);

            
        }

        /// <summary>
        /// Draws a hand symbol if the hand is tracked: red circle = closed, green circle = opened; blue circle = lasso
        /// </summary>
        /// <param name="handState">state of the hand</param>
        /// <param name="handPosition">position of the hand</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        private void DrawHand(HandState handState, Point handPosition, DrawingContext drawingContext)
        {
            switch (handState)
            {
                case HandState.Closed:
                  //  drawingContext.DrawEllipse(this.handClosedBrush, null, handPosition, HandSize, HandSize);
                    break;

                case HandState.Open:
                   // drawingContext.DrawEllipse(this.handOpenBrush, null, handPosition, HandSize, HandSize);
                    break;

                case HandState.Lasso:
                    //drawingContext.DrawEllipse(this.handLassoBrush, null, handPosition, HandSize, HandSize);
                    break;
            }
        }

        /// <summary>
        /// Draws indicators to show which edges are clipping body data
        /// </summary>
        /// <param name="body">body to draw clipping information for</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        private void DrawClippedEdges(Body body, DrawingContext drawingContext)
        {
            FrameEdges clippedEdges = body.ClippedEdges;

            if (clippedEdges.HasFlag(FrameEdges.Bottom))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(0, this.displayHeight - ClipBoundsThickness, this.displayWidth, ClipBoundsThickness));
            }

            if (clippedEdges.HasFlag(FrameEdges.Top))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(0, 0, this.displayWidth, ClipBoundsThickness));
            }

            if (clippedEdges.HasFlag(FrameEdges.Left))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(0, 0, ClipBoundsThickness, this.displayHeight));
            }

            if (clippedEdges.HasFlag(FrameEdges.Right))
            {
                drawingContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(this.displayWidth - ClipBoundsThickness, 0, ClipBoundsThickness, this.displayHeight));
            }
        }

        /// <summary>
        /// Handles the event which the sensor becomes unavailable (E.g. paused, closed, unplugged).
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            // on failure, set the status text
            this.StatusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
                                                            : Properties.Resources.SensorNotAvailableStatusText;
        }
    }
}
