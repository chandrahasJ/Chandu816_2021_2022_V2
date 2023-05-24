import 'package:flutter/material.dart';
import "package:velocity_x/velocity_x.dart";

class ProductImage extends StatelessWidget {
  final String imageSrc;

  const ProductImage({Key? key, required this.imageSrc}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Image.network(imageSrc)
        .box
        .p8
        .rounded
        .color(context.canvasColor)
        .make()
        .p16()
        .w40(context);
  }
}
