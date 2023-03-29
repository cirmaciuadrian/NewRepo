import { Box, Container, Stack } from '@mui/material';
import Head from 'next/head';
import Navbar from '../Navbar/Navbar';

interface Props {
  children: React.ReactNode;
}

function DefaultLayout({ children }: Props) {
  return (
    <Stack>
      <Head>
        <title>BACDE10</title>
        <meta name="description" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
      </Head>
      <Box>
        <Navbar />
        <Container maxWidth={false} disableGutters>
          {children}
        </Container>
      </Box>
    </Stack>
  );
}

export default DefaultLayout;
