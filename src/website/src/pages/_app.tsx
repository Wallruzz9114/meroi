import { AppProps } from 'next/app';
import '../styles/globals.css';

const Meroi = ({ Component, pageProps }: AppProps) => {
  return <Component {...pageProps} />;
};

export default Meroi;
