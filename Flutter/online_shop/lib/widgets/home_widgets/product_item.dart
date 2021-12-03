import 'package:flutter/material.dart';
import 'package:online_shop/Models/product.dart';
import 'package:online_shop/Themes/custom_themes.dart';
import 'package:online_shop/widgets/home_widgets/product_image.dart';
import "package:velocity_x/velocity_x.dart";

class ProductItem extends StatelessWidget {
  final ProductDetail productDetail;
  const ProductItem({Key? key, required this.productDetail}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return VxBox(
        child: Row(
      children: [
        ProductImage(
          imageSrc: productDetail.image,
        ),
        Expanded(
            child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            productDetail.name.text.lg.color(CustomThemes.bluishColor).make(),
            productDetail.desc.text.textStyle(context.captionStyle!).make(),
            10.heightBox,
            ButtonBar(
              alignment: MainAxisAlignment.spaceBetween,
              buttonPadding: EdgeInsets.zero,
              children: [
                "\$${productDetail.price}".text.bold.xl.make(),
                ElevatedButton(
                    onPressed: () {},
                    style: ButtonStyle(
                        backgroundColor:
                            MaterialStateProperty.all(CustomThemes.bluishColor),
                        shape:
                            MaterialStateProperty.all(const StadiumBorder())),
                    child: "Buy".text.make())
              ],
            ).pOnly(right: 8.0)
          ],
        ))
      ],
    )).white.rounded.square(100).make().py16();
  }
}
