export interface Game {
  id: number;
  name: string;
  releaseDate: string;
  price?: number;
  developer: string;
  image?: string;
  gameGenres?: string;
}
