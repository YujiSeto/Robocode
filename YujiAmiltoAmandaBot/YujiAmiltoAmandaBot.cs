using Robocode;
using Robocode.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YujiAmiltoAmandaBot
{
    //Created By Rodrigo Yuji / Amilto Romagno / Amanda Limas / BSI / Unisociesc

    public class YujiAmiltoAmandaBot : Robot
    {
        private double quantidadeMovimentacao; // Quantidade de locomoção

        public override void Run()
        {
            ///Características do Robo

            //Cor do Corpo
            BodyColor = (Color.Red);
            //Cor da Arma
            GunColor = (Color.LightGray);
            //Cor do Radar
            RadarColor = (Color.Orange);
            //Cor do Tiro
            BulletColor = (Color.PaleVioletRed);
            //Cor do Scan
            ScanColor = (Color.SkyBlue);

            ///Movimentar

            // Inicializa a quantidade de movimento de acordo com o campo de batalha
            quantidadeMovimentacao = Math.Max(BattleFieldWidth, BattleFieldHeight);

            //Vira o corpo Robo a Esquerda a 90°
            TurnLeft(Heading - 90);

            //Move para Frente o Robo de acordo com o campo de batalha
            Ahead(quantidadeMovimentacao);

            //Vira a Arma do Robo a Direita a 90°
            TurnGunRight(90);

            //Vira o corpo Robo a Direita a 90°
            TurnRight(90);

            while (true)
            {
                //Move para Frente o Robo de acordo com o campo de batalha
                Ahead(quantidadeMovimentacao);

                //Vira a Arma do Robo a Direita a 360°
                TurnGunRight(360);

                //Move para Trás o Robo de acordo com o campo de batalha
                Back(quantidadeMovimentacao);

                //Vira a Arma do Robo a Esquerda a 360°
                TurnGunLeft(360);
            }
        }

        ///Atirar

        //Atira ao Scanear um Robo
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            //Atira
            Fire(3);
            //Trava o Tiro no Oponente se ele ficar parado
            Scan();
        }

        ///Mirar

        //Mira de onde veio o Tiro
        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            double mirar = Utils.NormalRelativeAngleDegrees(evnt.Bearing + Heading - GunHeading);
            TurnGunRight(mirar);
        }

        //Mira no Robo que bater
        public override void OnHitRobot(HitRobotEvent evnt)
        {
            double mirar = Utils.NormalRelativeAngleDegrees(evnt.Bearing + Heading - GunHeading);
            TurnGunRight(mirar);
        }
    }
}
