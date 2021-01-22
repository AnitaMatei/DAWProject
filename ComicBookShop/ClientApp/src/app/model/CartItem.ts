import {Product} from '../model/Product';

export type CartItem = {
    quantity: number;
    correspondingComicBook: Product;
};