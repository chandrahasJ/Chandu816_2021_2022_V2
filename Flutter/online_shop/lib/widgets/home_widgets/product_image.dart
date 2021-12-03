import 'package:flutter/material.dart';
import 'package:online_shop/Themes/custom_themes.dart';
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
        .color(CustomThemes.creamColor)
        .make()
        .p16()
        .w40(context);
  }
}
