import { AppBar, CssBaseline, Toolbar, Typography } from '@mui/material';
import Link from 'next/link';
import styles from './styles/Navbar.module.css';

function Navbar() {
  return (
    <AppBar position="static" elevation={8}>
      <CssBaseline />
      <Toolbar>
        <Typography variant="h4" className={styles.logo}>
          Bac de 10
        </Typography>
        <div className={styles.navlinks}>
          <Link href="/" className={styles.link}>
            Home
          </Link>
          <Link href="/about" className={styles.link}>
            About
          </Link>
          <Link href="/" className={styles.link}>
            Contact
          </Link>
          <Link href="/" className={styles.link}>
            FAQ
          </Link>
        </div>
      </Toolbar>
    </AppBar>
  );
}
export default Navbar;
