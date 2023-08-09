﻿using System;
using System.Collections.Generic;
using CoreV01.Feeder;
using CoreV01.Properties;
using netDxf;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Tables;

namespace CADCore {
    public class Class1 {
        // https://github.com/haplokuon/netDxf/tree/master
        private DxfDocument doc;

        // your DXF file name
        string file = "sample.dxf";
        private Layer main, table, text;


        public Class1() {
            // create a new document, by default it will create an AutoCad2000 DXF version
            doc = new DxfDocument();
            main = new Layer("ЭМ линии");
            table = new Layer("ЭМ Таблица");
            text = new Layer("ЭМ Текст");
        }

        public void New() {
            // an entity


            Line entity = new Line(new Vector2(5, 5), new Vector2(10, 5));

            entity.Layer = main;

            // add your entities here
            doc.Entities.Add(entity);

            // save to file
            doc.Save(file);

            // this check is optional but recommended before loading a DXF file
            DxfVersion dxfVersion = DxfDocument.CheckDxfFileVersion(file);
            // netDxf is only compatible with AutoCad2000 and higher DXF versions
            if (dxfVersion < DxfVersion.AutoCad2000) return;

            // load file
            DxfDocument loaded = DxfDocument.Load(file);
        }

        /// <summary>
        /// Отрисовка штампа однолинейной схемы
        /// </summary>
        /// <param name="start">На вход идут координаты по нижнему - левому краю старта</param>
        /// <returns>возвращет правый нижний край конца</returns>
        public Vector2 DrawDiagramFrame(Vector2 start) {
            List<double[]> cooding = new List<double[]>() {
                new[] { 70.00, 70.00, 10.00, 70.00 },
                new[] { 35.00, 85.00, 35.00, 200.00 },
                new[] { 70.00, 85.00, 0.00, 85.00 },
                new[] { 70.00, 155.00, 0.00, 155.00 },
                new[] { 70.00, 130.00, 0.00, 130.00 },
                new[] { 70.00, 270.00, 0.00, 270.00 },
                new[] { 70.00, 0.00, 70.00, 270.00 },
                new[] { 70.00, 260.00, 0.00, 260.00 },
                new[] { -0.99, 0.32, 0.00, 0.00 },
                new[] { 70.00, 70.00, 10.00, 70.00 },
                new[] { 70.00, 200.00, 0.00, 200.00 },
                new[] { 15.00, 200.00, 15.00, 260.00 },
                new[] { 70.00, 240.00, 0.00, 240.00 },
                new[] { 70.00, 220.00, 0.00, 220.00 },
                new[] { 70.00, 20.00, 10.00, 10.00 },
                new[] { 70.00, 20.00, 10.00, 20.00 },
                new[] { 70.00, 10.00, 10.00, 10.00 },
                new[] { 70.00, 30.00, 10.00, 30.00 },
                new[] { 70.00, 50.00, 10.00, 50.00 },
                new[] { 70.00, 40.00, 10.00, 40.00 },
                new[] { 10.00, 0.00, 10.00, 85.00 }
            };

            foreach (var coord in cooding) {
                Line entity = new Line(new Vector2(coord[0], coord[1]), new Vector2(coord[2], coord[3]));
                entity.Layer = table;
                // add your entities here
                doc.Entities.Add(entity);
            }

            List<TextData> textDatas = new List<TextData>() {
                ///1.5707963 угол в 90 градусов
                new TextData(new Vector2(11.5309, 210.00), 1.5707963, "Пусковой \\Pаппарат"),
                new TextData(new Vector2(42.50, 206.0804), 0, "Тип, \\PIн"),
                new TextData(new Vector2(42.50, 222.50),
                    0,
                    "\\W0.8xОбозначение, \\PТип, \\PIн\\P{\\OТип характеристики Iрасц/I\\H0.64x;\\oΔ}"),
                new TextData(new Vector2(11.5309, 250.00), 1.5707963, "Сборные \\Pшины"),
                new TextData(new Vector2(12.7856, 230.00), 1.5707963, "\\W0.8xАппараты \\Pотходящих \\Pлиний"),
                new TextData(new Vector2(43.27, 242.00),
                    0,
                    "Напряжение, \\PУстановленная мощность, \\PРасчетная мощность, \\PРасчетный ток"),
                new TextData(new Vector2(35.00, 265.00), 0, "Данные питающей сети"),
                new TextData(new Vector2(17.50, 177.50), 0, "Марка и \\Pсечение \\Pкабеля"),
                new TextData(new Vector2(55.00, 12.50), 0, "{\\H0.64x;Δ}U/{\\H0.64x;Δ}Uпуск"),
                new TextData(new Vector2(40.00, 1.33), 0, "Номер по ГП \\P(экспликации помещений)"),
                new TextData(new Vector2(25.00, 17.50), 0, "Iокз"),
                new TextData(new Vector2(40.00, 25.00), 0, "\\W0.8xКласс взрыво-, пожароопасных зон"),
                new TextData(new Vector2(40.00, 35.00), 0, "Iном/Iпуск, А"),
                new TextData(new Vector2(17.50, 107.50), 0, "Марка и сечение \\Pкабеля"),
                new TextData(new Vector2(52.50, 107.50), 0, "Обозначение \\Pучастка, \\Pдлина"),
                new TextData(new Vector2(52.50, 142.50), 0, "Обозначение, \\Pтип"),
                new TextData(new Vector2(55.00, 177.50), 0, "Обозначение \\Pучастка, \\Pдлина"),
                new TextData(new Vector2(17.50, 137.9812), 0, "Аппараты \\Pконтроля и \\Pзащиты"),
                new TextData(new Vector2(5.00, 42.50), 1.5707963, "Электроприемник"),
                new TextData(new Vector2(40.00, 45.00), 0, "Рном, кВт"),
                new TextData(new Vector2(40.00, 77.50), 0, "\\W0.8xУсловно-графическое обозначение"),
                new TextData(new Vector2(40.00, 60.00), 0, "Обозначение, тип, \\Pнаименование механизма"),
            };

            foreach (var data in textDatas) {
                MText entity = DimensionTextByData(data);
                entity.Layer = text;
                // add your entities here
                doc.Entities.Add(entity);
            }

            SaveFile();
            return new Vector2(70, 0);
        }

        private MText DimensionText(Vector2 position, double rotation, string text) {
            MText mText = new MText(text, position, 2.5, 0.0) {
                AttachmentPoint = MTextAttachmentPoint.BottomCenter,
                Rotation = rotation * MathHelper.RadToDeg
            };

            return mText;
        }

        private MText DimensionTextByData(TextData data) {
            return DimensionText(data.Position, data.Rotation, data.Text);
        }

        private void SaveFile() {
            // save to file
            doc.Save(file);

            // this check is optional but recommended before loading a DXF file
            DxfVersion dxfVersion = DxfDocument.CheckDxfFileVersion(file);
            // netDxf is only compatible with AutoCad2000 and higher DXF versions
            if (dxfVersion < DxfVersion.AutoCad2000) throw new Exception("Версия ниже AutoCad2000");

            // load file
            DxfDocument loaded = DxfDocument.Load(file);
        }

        public Vector2 DrawIntroductoryUnit(Vector2 start, BaseCircuitBreaker circuitBreaker = null,
            BaseElectricalPanel electricalPanel = null) {
            double[] delta = GetDelta(start);
            List<double[]> linesCoordinate = new List<double[]>() {
                new[] { 10.10, 234.37, 10.10, 203.00 },
                new[] { 5.10, 206.78, 10.10, 203.00 },
                new[] { 3.10, 249.29, 3.10, 206.78 },
                new[] { 8.02, 236.77, 7.15, 237.27 },
                new[] { 10.80, 233.66, 9.39, 235.07 },
                new[] { 10.80, 235.07, 9.39, 233.66 },
                new[] { 8.15, 239.00, 9.02, 238.50 },
                new[] { 10.10, 240.37, 7.10, 235.17 },
                new[] { 7.15, 237.27, 8.15, 239.00 },
                new[] { 8.69, 253.63, 11.50, 254.68 },
                new[] { 8.69, 252.34, 11.50, 253.39 },
                new[] { 0.00, 10.00, 30.00, 20.00 },
                new[] { 0.00, 258.04, 9.35, 258.04 },
                new[] { 10.85, 258.04, 30.00, 258.04 },
                new[] { 8.69, 251.05, 11.50, 252.10 },
                new[] { 10.10, 257.29, 10.10, 240.37 },
                new[] { 5.10, 247.29, 5.10, 206.78 },
                new[] { 0.00, 70.00, 0.00, 0.00 },
                new[] { 10.10, 203.00, 10.10, 74.72 },
                new[] { 5.85, 248.04, 30.00, 248.04 },
                new[] { 0.00, 250.04, 2.35, 250.04 },
                new[] { 0.00, 248.04, 4.35, 248.04 },
                new[] { 3.85, 250.04, 30.00, 250.04 },
                new[] { 5.12, 256.63, 2.29, 259.46 },
                new[] { 0.00, 50.00, 30.00, 50.00 },
                new[] { 6.62, 256.63, 3.79, 259.46 },
                new[] { 0.00, 70.00, 30.00, 70.00 },
                new[] { 3.62, 256.63, 0.79, 259.46 },
                new[] { 0.00, 40.00, 30.00, 40.00 },
                new[] { 0.00, 0.00, 30.00, 0.00 },
                new[] { 0.00, 10.00, 30.00, 10.00 },
                new[] { 0.00, 30.00, 30.00, 30.00 },
                new[] { 0.00, 20.00, 30.00, 20.00 },
                new[] { 3.10, 206.78, 10.10, 203.00 },
                new[] { 30.00, 70.00, 30.00, 0.00 }
            };

            AddLineToDoc(linesCoordinate, delta);
            List<double[]> circlesCoordinate = new List<double[]>() {
                new[] { 5.10, 248.04, 0.75 },
                new[] { 3.10, 250.04, 0.75 },
                new[] { 10.10, 258.04, 0.75 }
            };
            AddCirclesToDoc(circlesCoordinate, delta);

            List<TextData> textCoordinate = new List<TextData>() {
                new TextData(new Vector2(15.65, 43.68),
                    0,
                    Math.Round(electricalPanel.RatedElectricPower, 2).ToString()),
                new TextData(new Vector2(15.91, 32.97), 0, Math.Round(electricalPanel.RatedCurrent, 2).ToString()),
                new TextData(new Vector2(16.09, 230.51),
                    0,
                    $"{circuitBreaker.ResponseCurve}{circuitBreaker.RatedCurrent}"),
                new TextData(new Vector2(15.93, 233.74), 0, $"{circuitBreaker.Dimensions}"),
                new TextData(new Vector2(16.03, 240.41), 0, $"{circuitBreaker.NameOnBus}"),
                new TextData(new Vector2(16.58, 237.41), 0, $"{circuitBreaker.Type}"),
                new TextData(new Vector2(14.98, 53.21), 0, electricalPanel.TechnologicalNumber)
            };
            AddTextToDoc(textCoordinate, delta);
            SaveFile();
            return new Vector2(30 + delta[0], 0 + delta[1]);
        }

        private void AddTextToDoc(List<TextData> textCoordinate, double[] delta) {
            foreach (var data in textCoordinate) {
                MText entity =
                    DimensionTextByData(new TextData(
                        new Vector2(data.Position.X + delta[0], data.Position.Y + delta[1]),
                        data.Rotation,
                        data.Text));
                entity.Layer = text;
                // add your entities here
                doc.Entities.Add(entity);
            }
        }

        private void AddCirclesToDoc(List<double[]> Coordinate, double[] delta) {
            foreach (var coord in Coordinate) {
                Circle entity = new Circle(new Vector2(coord[0] + delta[0], coord[1] + delta[1]), coord[2]);
                entity.Layer = table;
                // add your entities here
                doc.Entities.Add(entity);
            }
        }

        private void AddLineToDoc(List<double[]> linesCoordinate, double[] delta) {
            foreach (var coord in linesCoordinate) {
                Line entity = new Line(new Vector2(coord[0] + delta[0], coord[1] + delta[1]),
                    new Vector2(coord[2] + delta[0], coord[3] + delta[1]));
                entity.Layer = table;
                // add your entities here
                doc.Entities.Add(entity);
            }
        }

        private double[] GetDelta(Vector2 start) {
            double[] delta = new double[2];
            delta[0] = start.X - 0;
            delta[1] = start.Y - 0;
            return delta;
        }
    }

    public class TextData {
        public Vector2 Position { get; }

        public double Rotation { get; }
        public string Text { get; }

        public TextData(Vector2 position, double rotation, string text) {
            Position = position;
            Rotation = rotation;
            Text = text;
        }
    }
}